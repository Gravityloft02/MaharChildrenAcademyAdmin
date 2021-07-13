using MaharChildrenAcademyAdmin.Helper;
using MaharChildrenAcademyAdmin.Interfaces;
using MaharChildrenAcademyAdmin.Models;
using MaharChildrenAcademyAdmin.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MaharChildrenAcademyAdmin.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult UploadImage()
        {
            //UploadFile();
            string[,] uploadedImages = new string[System.Web.HttpContext.Current.Request.Files.Count, 2];
            int count = 0;
            HttpFileCollectionBase files = Request.Files;

            for (int i = 0; i < files.Count; i++)
            //foreach (var fileWrapper in Request.Files)
            {
                //var uploadFile = //(HttpPostedFileBase) file;
                //HttpPostedFileBase file = fileWrapper as HttpPostedFileBase;
                HttpPostedFileBase file = files[i];
                var uploadedImage = UploadImage(file);
                uploadedImages[count, 0] = uploadedImage[0];
                uploadedImages[count, 1] = uploadedImage[1];
                count = count + 1;
            }

            return Json(new
            {
                filePath = uploadedImages
            });
        }

        private string[] UploadImage(HttpPostedFileBase uploadFile)
        {
            //var ss = UploadFile(uploadFile);

            string[] uploadedImage = new string[2];
            var currenturl = Request.Url.Scheme + "://" + Request.Url.Authority;
            string uploadPath = ConfigHelper.UPLOAD_LOCATION;
            string uploadFileName = Path.GetFileNameWithoutExtension(uploadFile.FileName) + DateTime.Now.Ticks.ToString() + Path.GetExtension(uploadFile.FileName);

            string filePath = HttpContext.Server.MapPath("~" + uploadPath);

            if (uploadFile != null && uploadFile.ContentLength > 0)
            {
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                filePath = Path.Combine(filePath, uploadFileName);
                uploadFile.SaveAs(filePath);
            }
            uploadPath = currenturl + uploadPath;
            uploadedImage[0] = uploadFile.FileName;
            uploadedImage[1] = Path.Combine(uploadPath, uploadFileName);
            return uploadedImage;
        }


        public string UploadFile()
        {
            byte[] imageArray = System.IO.File.ReadAllBytes(@"d:\test.pdf");
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);
            DocumentModel document = new DocumentModel();
            document.AppName = "App";
            document.Base64EncryptedData = base64ImageRepresentation;
            document.DocumentType = 1;
            document.FileName = "aa.pdf";
            document.Identity = Guid.NewGuid().ToString();
            document.ImageArray = imageArray;
            document.ImageType = 1;
            document.UniqueDocumentId = 3;

            IDocument _document = new DocumentService();
            Task.Run(
               async () =>
               {
                   await _document.UploadDocuments(document);
               });
            return "";
        }

    }
}