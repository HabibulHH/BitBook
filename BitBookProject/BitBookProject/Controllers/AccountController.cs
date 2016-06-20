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
                Session["UserName"] = user.UserName;
                ViewBag.SuccessMessage = "LogIn Successfully";
                return RedirectToAction("LoggedIn", "Account");
            }
            else
            {
                ViewBag.ErrorMessage = " Email or Password is not Vaild";
            }

            return View();
        }

        public ActionResult LoggedIn()
        {
           if (Session["UserName"]!=null)
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