using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBook.Models;
namespace WebBook.Controllers
{
    public class LoginPageController : Controller
    {
        BookShopEntities db = new BookShopEntities();
        // GET: LoginPage
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CheckAuthen(NguoiDung nd)
        {
            NguoiDung tmp = db.NguoiDungs.Where(m => m.TaiKhoan == nd.TaiKhoan).First(); 
            if ( tmp.MatKhau.Equals(nd.MatKhau))
            {
                return RedirectToAction("Index", "HomePage");
            }
            return View("Index");
        }
    }
}