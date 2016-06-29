using System;
using System.Collections.Generic;
using System.IO;
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
            Session["User"] = userData;
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
            if (ModelState.IsValid)
            {
                userManager.SaveUser(user);
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        public ActionResult EditProfile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditProfile(User model, HttpPostedFileBase file)
        {

            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    string path=Path.Combine(Server.MapPath("~/Design Content/img"),
                                                              Path.GetFileName(file.FileName));
                    string pathofdatabse = Path.Combine(("~/Design Content"),
                        Path.GetFileName(file.FileName));
                    User user = userManager.GetUserByUserId(model.UserId);

                    user.ProfilePicture = pathofdatabse; 
                if (userManager.UploadProfilePicture(user))
                {
                    file.SaveAs(path);
                    ViewBag.UpdateMessageforProfile = "Update Successfully";
                    user.ProfilePicture =userManager.GetProfilePhoto(user).ProfilePicture;
                    return RedirectToAction("Profiles", "Profiles", user);

                }
                else
                {
                    ViewBag.ErrorMessageForProfile = "Update Failed";
                }

            }

  
            }
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


        public ActionResult GetProfilePhoto( User user)
        {
            User aUser=new User(); 
            aUser=userManager.GetProfilePhoto(user);
            return RedirectToAction("Profiles", "Profiles",aUser);
        }

    }
}
