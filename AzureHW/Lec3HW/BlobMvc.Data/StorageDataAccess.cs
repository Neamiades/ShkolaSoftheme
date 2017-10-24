using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.RetryPolicies;

namespace BlobMvc.Data
{
    public static class StorageDataAccess
    {
        private const string ConnectionStringSettingName = "StorageConnectionString";
        public  const string ContainerName               = "test";

        //5 * 1024 * 1024 bytes or 5 MB
        private const int BlockSize = 5_242_880;

        private static readonly string ConnectionString = CloudConfigurationManager.GetSetting(ConnectionStringSettingName);
        private static readonly CloudBlobContainer CloudBlobContainer = GetContainerReference();

        #region Upload & Download

        public static void Upload(byte[] file, string fileName) => UploadFileInBlocks(file, fileName);

        public static void SimpleUpload(byte[] file, string fileName)
        {
            CloudBlockBlob blockBlob = CloudBlobContainer.GetBlockBlobReference(fileName);
            blockBlob.UploadFromByteArray(file, 0, file.Length);
        }

        public static void SimpleParallelUpload(byte[] file, string fileName)
        {
            CloudBlockBlob blob = CloudBlobContainer.GetBlockBlobReference(Path.GetFileName(fileName));

            BlobRequestOptions requestOptions = new BlobRequestOptions
            {
                SingleBlobUploadThresholdInBytes = BlockSize * 2,
                ParallelOperationThreadCount = 2
            };
            
            blob.StreamWriteSizeInBytes = BlockSize;
            
            blob.UploadFromByteArray(file, 0, file.Length, null, requestOptions);
        }

        public static void ParallelUpload(byte[] file, string fileName, int blockSize = BlockSize)
        {
            CloudBlockBlob blob = CloudBlobContainer.GetBlockBlobReference(Path.GetFileName(fileName));

            blob.DeleteIfExists();

            int fileSize = file.Length;
            int tasksCount = (int)Math.Ceiling((double)fileSize / blockSize);
            var blockIDs = new string[tasksCount];
            var blobReqOpt = new BlobRequestOptions { RetryPolicy = new ExponentialRetry(TimeSpan.FromSeconds(2), 1) };

            blockSize = Math.Min(blockSize, fileSize);

            Parallel.For(0, tasksCount, blockId =>
            {
                int byteIdx = blockId * blockSize;
                int blockLength = Math.Min(blockSize, fileSize - byteIdx);

                string blockIdEncoded = GetBase64BlockId(blockId);

                byte[] bytesToUpload = new byte[blockLength];
                Array.Copy(file, byteIdx, bytesToUpload, 0, blockLength);

                using (MemoryStream memoryStream = new MemoryStream(bytesToUpload, 0, blockLength))
                {
                    lock (blob)
                    {
                        blockIDs[blockId] = blockIdEncoded;
                        blob.PutBlock(blockIdEncoded, memoryStream, null, null, blobReqOpt);
                    }
                }
            });

            blob.PutBlockList(blockIDs);
        }

        public static byte[] DownloadFile(string fileName)
        {
            CloudBlockBlob blob = CloudBlobContainer.GetBlockBlobReference(Path.GetFileName(fileName));

            blob.FetchAttributes();
            long fileSize = blob.Properties.Length;

            byte[] blobContents = new byte[fileSize];
            int position = 0;

            while (fileSize > 0)
            {
                int blockLength = (int)Math.Min(BlockSize, fileSize);

                blob.DownloadRangeToByteArray(blobContents, position, position, blockLength);

                position += blockLength;
                fileSize -= BlockSize;
            }

            return blobContents;
        }

        public static byte[] DownloadFileParallel(string fileName, int blockSize = BlockSize)
        {
            CloudBlockBlob blob = CloudBlobContainer.GetBlockBlobReference(Path.GetFileName(fileName));

            blob.FetchAttributes();
            long fileSize = blob.Properties.Length;
            byte[] blobContents = new byte[fileSize];
            int position = 0;

            int tasksCount = (int)Math.Ceiling((double)fileSize / blockSize);
            var tasks = new Task[tasksCount];
            for (int i = 0; i < tasksCount; i++, position += blockSize)
            {
                tasks[i] = Task.Factory.StartNew((pos) =>
                {
                    int blockLength = (int)Math.Min(blockSize, fileSize - (int)pos);

                    blob.DownloadRangeToByteArray(blobContents, (int)pos, (int)pos, blockLength);

                }, position);
            }
            Task.WaitAll(tasks);

            return blobContents;
        }

        private static void UploadFileInBlocks(byte[] file, string fileName)
        {
            CloudBlockBlob blob = CloudBlobContainer.GetBlockBlobReference(Path.GetFileName(fileName));

            blob.DeleteIfExists();

            List<string> blockIDs = new List<string>();
            long fileSize = file.Length;

            int blockId = 0;

            while (fileSize > 0)
            {
                int blockLength = (int)Math.Min(BlockSize, fileSize);

                string blockIdEncoded = GetBase64BlockId(blockId);
                blockIDs.Add(blockIdEncoded);

                byte[] bytesToUpload = new byte[blockLength];
                Array.Copy(file, blockId * BlockSize, bytesToUpload, 0, blockLength);

                using (MemoryStream memoryStream = new MemoryStream(bytesToUpload, 0, blockLength))
                {
                    blob.PutBlock(blockIdEncoded, memoryStream, null, null, new BlobRequestOptions
                    {
                        RetryPolicy = new ExponentialRetry(TimeSpan.FromSeconds(2), 1)
                    });
                }

                blockId++;
                fileSize -= blockLength;
            }

            blob.PutBlockList(blockIDs);
        }

        #endregion

        public static List<IListBlobItem> ListBlobs() => CloudBlobContainer.ListBlobs(null, true).ToList();

        private static string GetBase64BlockId(int blockId) => Convert.ToBase64String(Encoding.ASCII.GetBytes($"{blockId:0000000}"));

        private static CloudBlobContainer GetContainerReference()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConnectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(ContainerName);

            container.CreateIfNotExists();

            return container;
        }
    }
}
