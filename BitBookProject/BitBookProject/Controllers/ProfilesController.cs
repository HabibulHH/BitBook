using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitBookProject.Controllers
{
    public class ProfilesController : Controller
    {
        // GET: Profiles
        public ActionResult Profiles()
        {
            return View();
        }

        public ActionResult Me()
        {
            return View();
        }


        
    }
}
