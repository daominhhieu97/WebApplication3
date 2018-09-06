using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBook.Models;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

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
        public ActionResult _GioHang()
        {
            int soluong = giohang.LST_SACHS.Count();
            ViewBag.SoLuongTrongGioHang = soluong;
            return PartialView();
        }
        public ActionResult DatHang()
        {
            return View(giohang);
        }
        [HttpPost]
        public async Task<ActionResult> MuaHang(FormCollection fc)
        {
            WebBook.Models.NguoiDung nd = Session["nguoidung"] as WebBook.Models.NguoiDung;
            DonHang dh = new DonHang();
            dh.ID_NguoiMua = nd.ID;
            dh.SoDT = fc["sodienthoai"].ToString();
            dh.DiaChiGiao = fc["diachi"].ToString();
            dh.TongTien = giohang.totalprice;
            DateTime today = DateTime.Now;
            dh.NgayDat = today;
            dh.TrangThai = false;
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

            //gửi email
            var body = "<p>Email From: {0} ({1})</p> <p>Message:</p><p>BẠN VỪA ĐẶT HÀNG THÀNH CÔNG ĐƠN HÀNG: " + dh.MaDonHang + "</p>" + "<p>TỔNG TIỀN: " + dh.TongTien + "</p>" + "<p>NGÀY ĐẶT HÀNG: " + dh.NgayDat + "</p>";
            var message = new MailMessage();
            message.To.Add(new MailAddress(nd.Email));  // replace with valid value 
            message.From = new MailAddress("hieudm97@gmail.com");  // replace with valid value
            message.Subject = "ĐẶT HÀNG THÀNH CÔNG";
            message.Body = string.Format(body, "ĐÀO MINH HIẾU", "hieudm97@gmail.com");
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "hieudm97@gmail.com",  // replace with valid value
                    Password = "hieudm231197"  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
            }
            return View();
        }
        public ActionResult ToanBoTheLoai()
        {
            ViewBag.Sachs = db.Saches.ToList();
            ViewBag.TheLoais = db.TheLoais.ToList();
            return View();
        }
        public ActionResult QuanLyGioHang()
        {
            NguoiDung nd = Session["nguoidung"] as NguoiDung;
            List<DonHang> lst_donhang = db.DonHangs.Where(m => m.ID_NguoiMua == nd.ID).ToList();
            return View(lst_donhang);
        }
        public ActionResult QuanLyNguoiDung(int id)
        {
            NguoiDung nd = db.NguoiDungs.Where(m => m.ID == id).First();
            return View(nd);
        }
        [HttpPost]
        public ActionResult CapNhatThongTinNguoiDung(NguoiDung nd)
        {
            NguoiDung capnhat = db.NguoiDungs.Where(m => m.ID == nd.ID).FirstOrDefault();
            capnhat.Ten = nd.Ten;
            capnhat.SDT = nd.SDT;
            capnhat.DiaChi = nd.DiaChi;
            capnhat.Email = nd.Email;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}