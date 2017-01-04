using ExamProject.Models;
using Microsoft.AspNet.Identity;
using System;
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

            var uId = User.Identity.GetUserId();

            using (var db = new ApplicationDbContext())
            {
                var me = db.Users.FirstOrDefault(x => x.Id == uId);
                if (me == null)
                    return new HttpNotFoundResult();

                if (!me.CompanyId.HasValue)
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.MethodNotAllowed, "Company ID is not set to the user");

                ViewBag.CompanyId = me.CompanyId;

            }
            ViewBag.UserName = userName;
            return View();
        }
    }
}