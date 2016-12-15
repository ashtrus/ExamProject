using ExamProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamProject.Controllers
{
    public class UploadController : Controller
    {

       

        // GET: Upload  
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult UploadFile()
        {
            return View();
        }


        [HttpPost] //Uploda file to local folder, from VIew  // over loading () 
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    file.SaveAs(_path);
                }
                ViewBag.Message = "File Uploaded Successfully!!"; // success message 

                return RedirectToAction("Index", "Home"); // Redirect to display Data on SUCCESS!
            }
            catch //Catch an Exception //Err handling
            {
                ViewBag.Message = "File upload failed!!";
                return View(); 
            }
        }

      //HTTP GET 
    
        public ActionResult Company()
        {

            
            return View(); 
        }
    }
}