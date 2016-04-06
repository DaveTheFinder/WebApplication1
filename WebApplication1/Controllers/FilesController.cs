using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class FilesController : Controller
    {
        private QuickAgenda db = new QuickAgenda();


        // GET: Files
        public ActionResult Index()
        {
            var files = db.Files.ToList();

            return View(files);
        }

        public ActionResult Save(FormCollection formCollection)
        {
            if(Request != null)
            {
                HttpPostedFileBase file = Request.Files["UploadedFile"];

                if((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    string fileName = file.FileName;
                    string fileContentType = file.ContentType;
                    byte[] fileBytes = new byte[file.ContentLength];
                    file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));

                    var entity = new Models.File
                    {
                        FileName = fileName,
                        ContentType = fileContentType,
                        fileBytes = fileBytes
                    };

                    db.Files.Add(entity);
                    db.SaveChanges();
                }
            }

            var files = db.Files.ToList();
            return View("Index", files);
        }


        public ActionResult GetFile(int id)
        {
            var file = db.Files.Find(id);

            var result = new FileContentResult(file.fileBytes, file.ContentType);
            result.FileDownloadName = file.FileName;

            return result;
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}