using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace ParalelZip
{
    static class Zipper
    {
        public static void Zip(DirectoryInfo directorySelected)
        {
            Task[] tasks = new Task[directorySelected.GetDirectories().Length];
            int i = 0;

            foreach (var dir in directorySelected.GetDirectories())
            {
                tasks[i++] = Task.Factory.StartNew(() => Zip(dir));
            }

            foreach (FileInfo fileToCompress in directorySelected.GetFiles())
            {
                using (FileStream originalFileStream = fileToCompress.OpenRead())
                {
                    if ((File.GetAttributes(fileToCompress.FullName) &
                       FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".gz")
                    {
                        using (FileStream compressedFileStream = File.Create(fileToCompress.FullName + ".gz"))
                        {
                            using (GZipStream compressionStream = new GZipStream(compressedFileStream,
                               CompressionMode.Compress))
                            {
                                originalFileStream.CopyTo(compressionStream);
                            }
                        }
                    }
                }
                fileToCompress.Delete();
            }
            Task.WaitAll(tasks);
        }

        public static void Unzip(DirectoryInfo directorySelected)
        {
            Task[] tasks = new Task[directorySelected.GetDirectories().Length];
            int i = 0;

            foreach (var dir in directorySelected.GetDirectories())
            {
                tasks[i++] = Task.Factory.StartNew(() => Unzip(dir));
            }

            foreach (FileInfo fileToDecompress in directorySelected.GetFiles("*.gz"))
            {
                using (FileStream originalFileStream = fileToDecompress.OpenRead())
                {
                    string currentFileName = fileToDecompress.FullName;
                    string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);

                    using (FileStream decompressedFileStream = File.Create(newFileName))
                    {
                        using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                        {
                            decompressionStream.CopyTo(decompressedFileStream);
                        }
                    }
                }
                fileToDecompress.Delete();
            }

            Task.WaitAll(tasks);
        }
    }
}
