﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamProject.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        // GET: Chat
        public ActionResult Index()
        {
            var userName = User.Identity.Name;
            ViewBag.UserName = userName;
            return View();
        }
    }
}