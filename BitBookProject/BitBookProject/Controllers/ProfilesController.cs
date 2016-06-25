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


        [HttpPost]
        public ActionResult EditProfile(User model, HttpPostedFileBase file)
        {



            if (file != null && file.ContentLength > 0)
            {


                // extract only the fielname
                var fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/Content/img"), fileName);
                model.ProfilePicture = path;
                User aUser = userManager.UploadImage(model);

                file.SaveAs(path);
                return RedirectToAction("Profiles", "Profiles", aUser);
            }
            return View();
        }


    }
}
