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
        private static GioHang giohang = new GioHang();

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
        public ActionResult TimKiem(string noidungtimkiem)
        {
            List<Sach> lst_sachs = db.Saches.Where(m => m.TenSach.Contains(noidungtimkiem)).ToList();
            return View(lst_sachs);
        }
        public ActionResult ThemSanPham(int id, string returnurl)
        {
            Sach sach = db.Saches.Where(m => m.ID == id).First();
            giohang.themsach(sach);
            return Redirect(returnurl);
        }
        public ActionResult XoaSanPham(int id)
        {
            Sach sach = giohang.LST_SACHS.Where(m => m.ID == id).First();
            giohang.xoasach(sach);
            return RedirectToAction("XemGioHang");

        }
        public ActionResult XemGioHang()
        {
            return View(giohang);
        }
        public ActionResult TheLoai(int id)
        {
            List<Sach> lst_sachs = db.Saches.Where(m => m.ID_TheLoai == id).ToList();
            string tentheloai = db.TheLoais.Where(m => m.ID == id).First().TenTheLoai;
            ViewBag.tentheloai = tentheloai;
            return View(lst_sachs);
        }
        [ChildActionOnly]
        public ActionResult _DanhSachTheLoai()
        {
            List<TheLoai> lst_theloais = db.TheLoais.ToList();
            return PartialView(lst_theloais);
        }
        public ActionResult DatHang()
        {
            return View(giohang);
        }
        [HttpPost]
        public ActionResult MuaHang(FormCollection fc)
        {
            WebBook.Models.NguoiDung nd = Session["nguoidung"] as WebBook.Models.NguoiDung;
            DonHang dh = new DonHang();
            dh.ID_NguoiMua = nd.ID;
            dh.SoDT = fc["sodienthoai"].ToString();
            dh.DiaChiGiao = fc["diachi"].ToString();
            dh.TongTien = giohang.totalprice;
            db.DonHangs.Add(dh);
            db.SaveChanges();
            foreach (var chitietdonhang in giohang.LST_SACHS)
            {
                ChiTiet ct = new ChiTiet();
                ct.ID_DonHang = dh.MaDonHang;
                ct.ID_Sach = chitietdonhang.ID;
                ct.SoLuongMua = 1;
                ct.TongTien = chitietdonhang.Gia * 1;
                db.ChiTiets.Add(ct);
                db.SaveChanges();
            }
            giohang.LST_SACHS.Clear();
            return View();
        }
        public ActionResult ToanBoTheLoai()
        {
            ViewBag.Sachs = db.Saches.ToList();
            ViewBag.TheLoais = db.TheLoais.ToList();
            return View();
        }
    }
}