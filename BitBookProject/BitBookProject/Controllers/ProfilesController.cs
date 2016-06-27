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
        UserManager userManager = new UserManager();

        public ActionResult Profiles(User user)
        {
            
            var userData = userManager.GetUserByUsername(user.UserName);
            Session["User"] = userData;
            return View(userData);
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

        [HttpPost]
        public ActionResult EditProfile(User model, HttpPostedFileBase file)
        {



            if (file != null && file.ContentLength > 0)
            {


                // extract only the fielname
                var fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/Content/img/"), fileName);
                

                
                User aUser = userManager.GetUserByUserId(model.UserId);
                aUser.ProfilePicture = path;
                file.SaveAs(path);
                if (userManager.UploadProfilePicture(aUser))
                {
                    file.SaveAs(path);
                    ViewBag.UpdateMessageforProfile = "Update Successfull";
                   
                    return RedirectToAction("Profiles", "Profiles", aUser);
                }
                else
                {
                    ViewBag.ErrorMessageForProfile = "Update Failed";
                }

               
                return RedirectToAction("Profiles", "Profiles", aUser);
            }
            return View();
        }
        [HttpPost]
        public ActionResult DeletePost(Status status)
        {
               
      
            StatusManager statusManager= new StatusManager();
            User aUser= userManager.GetUserByUserId(status.UserId);
            if (statusManager.DeletePost(status));
            ViewBag.message = "Deleted";
            return RedirectToAction("Profiles", "Profiles", aUser);
        
        }


    }
}
