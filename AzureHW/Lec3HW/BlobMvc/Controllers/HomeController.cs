using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.WindowsAzure.Storage.Blob;
using BlobMvc.Data;

namespace BlobMvc.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Container = StorageDataAccess.ContainerName;
            return View(StorageDataAccess.ListBlobs().Select(b => (CloudBlockBlob)b));
        }

        [HttpPost]
        public ActionResult Index(string uploadType, HttpPostedFileBase file)
        {
            if (file != null)
            {
                byte[] avatar = new byte[file.ContentLength];
                file.InputStream.Read(avatar, 0, file.ContentLength);

                string fileName = System.IO.Path.GetFileName(file.FileName);
                if (uploadType.Equals("simple"))
                {
                    StorageDataAccess.Upload(avatar, $"Simple{fileName}");
                }
                else
                {
                    StorageDataAccess.ParallelUpload(avatar, $"Parallel{fileName}");
                }
            }

            ViewBag.Container = StorageDataAccess.ContainerName;
            return View(StorageDataAccess.ListBlobs().Select(b => (CloudBlockBlob)b));
        }

        [HttpGet]
        public FileResult Download(string blobName)
        {
            byte[] fileBytes = StorageDataAccess.DownloadFile(blobName);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, blobName);
        }

        [HttpGet]
        public FileResult DownloadInParallel(string blobName)
        {
            byte[] fileBytes = StorageDataAccess.DownloadFileParallel(blobName);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, blobName);
        }
    }
}