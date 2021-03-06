﻿using System;
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
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login(User user)
        {
            if (userManager.Login(user))
            {
                User aUser = userManager.GetUserByUsername(user.UserName);
                ViewBag.SuccessMessage = "LogIn Successfully";
                return RedirectToAction("Profiles", "Profiles", aUser);
            }
            else
            {
                ViewBag.ErrorMessage = " Email or Password is not Vaild";
            }

            return View();
        }

        public ActionResult LoggedIn()
        {
           if (Session["User"]!=null)
            {
             
               //userManager.GetUserByUsername()
                return RedirectToAction("Profiles", "Profiles");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Login", "Account");
        }
}
}