using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBook.Models;

namespace WebBook.Controllers
{
    public class HomePageController : Controller
    {
        BookShopEntities db = new BookShopEntities();
        // GET: HomePage
        public ActionResult Index()
        {
            List<Sach> lst_sachs = db.Saches.ToList();
            return View(lst_sachs);
        }
        public ActionResult GioiThieu()
        {
            return View();
        }
        public ActionResult LienHe()
        {
            return View();
        }
    }
}