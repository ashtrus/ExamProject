﻿using ExamProject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamProject.Controllers
{
    public class HomeController : Controller
    {
       
        private ApplicationDbContext db = new ApplicationDbContext(); 


        /*
         [Authorize]
         public ActionResult Index()
         {
             var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

             string userId = User.Identity.GetUserId();

             var user = userManager.FindById(userId);
             //var company = user.Company;

             //Redirect if not ADMIN 
             if (!User.IsInRole("Admin"))
             {
                 return View(notAuth());
             }

             return View(); //Company 
         }*/




        public ActionResult Index ()
        {
           return View(); 
        }
       
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       

        public ActionResult Company()
        {
            return View(); 
        }

     
    }
}