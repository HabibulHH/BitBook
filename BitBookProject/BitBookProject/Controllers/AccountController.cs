using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BitBookProject.BLL;
using BitBookProject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace BitBookProject.Controllers
{
    public class AccountController : Controller
    {



        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        public AccountController()
            : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
        }

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }
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

        public ActionResult Registraion()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Registraion(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser() { UserName = model.UserName };
                user.Email = model.Email;
                user.ConfirmedEmail = false;
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    System.Net.Mail.MailMessage m = new System.Net.Mail.MailMessage(
                        new System.Net.Mail.MailAddress("galibwow@hotmail.com", "Web Registration"),
                        new System.Net.Mail.MailAddress(user.Email));
                    m.Subject = "Email confirmation";
                    m.Body = string.Format("Dear {0}<BR/>Thank you for your registration, please click on the below link to complete your registration: <a href=\"{1}\" title=\"User Email Confirm\">{1}</a>", user.UserName, Url.Action("ConfirmEmail", "Account", new { Token = user.Id, Email = user.Email }, Request.Url.Scheme));
                    m.IsBodyHtml = true;
                    System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("galibwow@gmail.com");
                    smtp.Credentials = new System.Net.NetworkCredential("galibwow@gmail.com", "galib01041991Ga!");
                    //smtp.ServerCertificateValidationCallback = () => true; 
                    return RedirectToAction("Confirm", "Account", new { Email = user.Email });
                }
                else
                {
                    AddErrors(result);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public ActionResult Confirm(string Email)
        {
            ViewBag.Email = Email;
            return View();
        }
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string Token, string Email)
        {
            ApplicationUser user = this.UserManager.FindById(Token);
            if (user != null)
            {
                if (user.Email == Email)
                {
                    user.ConfirmedEmail = true;
                    await UserManager.UpdateAsync(user);
                    await SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home", new { ConfirmedEmail = user.Email });
                }
                else
                {
                    return RedirectToAction("Confirm", "Account", new { Email = user.Email });
                }
            }
            else
            {
                return RedirectToAction("Confirm", "Account", new { Email = "" });
            }

        }

        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Login", "Account");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
}
}