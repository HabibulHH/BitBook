using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitBookFinal.Core.BLL;
using BitBookFinal.Models;

namespace BitBookFinal.Controllers
{
    public class UserController : Controller
    {
        UserManager userManager=new UserManager();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User Model)
        {
           
                if (ModelState.IsValid)
                {
                    var isSaved = userManager.SaveUser(Model);
                    if (isSaved)
                    {
                        ViewBag.SuccessMessage = "User has been saved successfully.";
                        
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Sorry User already Exist.";
                    }
                    return View(Model);
                }
       
            return RedirectToAction("Create");
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
