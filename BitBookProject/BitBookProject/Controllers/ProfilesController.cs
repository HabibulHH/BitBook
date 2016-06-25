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
        UserManager userManager = new UserManager();

        public ActionResult Profiles(string userName)
        {
          var userData=  userManager.GetUserByUsername(userName);

            
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
      


    }
}
