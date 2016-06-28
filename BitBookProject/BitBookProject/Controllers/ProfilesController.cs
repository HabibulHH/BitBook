using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitBookProject.BLL;
using BitBookProject.Models;

namespace BitBookProject.Controllers
{
    public class ProfilesController : Controller
    {
        // GET: Profiles
        StatusManager statusManager =new StatusManager();
        UserManager userManager = new UserManager();

        public ActionResult Profiles(User user)
        {
            
            var userData = userManager.GetUserByUsername(user.UserName);
            var staus = statusManager.getStatusOfUser(user);
            ViewBag.status = staus;
            return View(userData);
        }

        public JsonResult LoadStatus(int UserId)
        {
            User user= new User();
            user.UserId = UserId;
            var staus = statusManager.getStatusOfUser(user);
            return Json(staus, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Registration()
        {

            return View();
        }

        [HttpPost]

        public ActionResult Registration(User user)
        {
            userManager.SaveUser(user);
            return View();
        }

        public ActionResult EditProfile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PostStatus(Status status)
        {
            StatusManager statusManager= new StatusManager();
            User aUser= userManager.GetUserByUserId(status.UserId);
            if (statusManager.saveStatus(status));
            ViewBag.message = "Posted";
            return RedirectToAction("Profiles", "Profiles", aUser);
        }


    }
}
