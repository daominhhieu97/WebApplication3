using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEBAPI.Models;

namespace WEBAPI.Controllers.API
{
    public class SachController : ApiController
    {
        BOOKWEBEntities db = new BOOKWEBEntities();
        
        public IHttpActionResult GetAllBook()
        {
            List<Models.DTO.Sach> lst = db.Saches.Select(s => new Models.DTO.Sach {
                ID = s.ID,
                TenSach = s.TenSach,
                Gia = s.Gia,
                SoTrang = s.SoTrang,
                Anhbia = s.Anhbia
            }).ToList<Models.DTO.Sach>();
            return Ok(lst);
        }
        public IHttpActionResult GetBookById(int id)
        {
            Models.DTO.Sach new_sach = db.Saches.Where(s => s.ID == id).Select(

                s => new Models.DTO.Sach {
                    ID = s.ID,
                    Gia = s.Gia,
                    SoTrang = s.SoTrang,
                    Anhbia = s.Anhbia,
                    TenSach = s.TenSach
                }).First();
            return Ok(new_sach);
        }
        public IHttpActionResult PostNewBook(Models.DTO.Sach newbook)
        {
            Sach newsach = new Sach()
            {
                TenSach = newbook.TenSach, 
                Gia = newbook.Gia, 
                SoTrang = newbook.SoTrang, 
                Anhbia = newbook.Anhbia
            };
            db.Saches.Add(newsach);
            db.SaveChanges();
            return Ok();
        }
        public IHttpActionResult deleteBook(int id)
        {
            Sach sach = db.Saches.Find(id);
            db.Saches.Remove(sach);
            db.SaveChanges();
            return Ok();
        }
        public IHttpActionResult PutBook(Models.DTO.Sach editBook)
        {
            Sach sach = db.Saches.Where(s => s.ID == editBook.ID).First();
            sach.TenSach = editBook.TenSach;
            sach.Gia = editBook.Gia;
            sach.SoTrang = editBook.SoTrang;
            db.SaveChanges();
            return Ok();
        }
     

    }
}
