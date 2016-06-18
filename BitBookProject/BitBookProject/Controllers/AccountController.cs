using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitBookProject.BLL;
using BitBookProject.Models;

namespace BitBookProject.Controllers
{
    public class AccountController : Controller
    {
        UserManager userManager = new UserManager();
        // GET: Account
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login(User user)
        {
            if (userManager.Login(user))
            {
                Session["Email"] = user.Email;
                Session["UserName"] = user.UserName;
                ViewBag.SuccessMessage = "LogIn Successfully";
                
            }
            else
            {
                ViewBag.ErrorMessage = " Email or Password is not Vaild";
            }
            //return RedirectToAction("LoggedIn", "Account");
            return RedirectToAction("Profiles", "Profiles");
        }

        public ActionResult LoggedIn()
        {
            if (Session["Email"] != null)
            {
                return View();
            }
            else if (Session["UserName"]!=null)
            {
                return RedirectToAction("Profiles", "Profiles");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
}
}