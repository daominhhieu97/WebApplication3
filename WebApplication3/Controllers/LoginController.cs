using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class LoginController : Controller
    {
        MULTICHOICEEntities db = new MULTICHOICEEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ToHome(FormCollection user)
        {
            USER u = new USER
            {
                USERNAME = user["USERNAME"],
                PASSWORD = user["PASSWORD"]
            };
            if(CheckUser(u))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [NonAction]
        public Boolean CheckUser(USER user)
        {
            if(db.USERs.Where(u => u.USERNAME == user.USERNAME).First()!= null)
                return true;
            return false;

        }
    }
}