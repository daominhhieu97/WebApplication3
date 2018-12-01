using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEBAPI.Models;

namespace WEBAPI.Controllers.API
{
    public class TheLoaiController : ApiController
    {
        BOOKWEBEntities db = new BOOKWEBEntities();
        public IHttpActionResult GetAllTheLoai()
        {
            List<Models.DTO.TheLoai> list_theloai = db.TheLoais.Select(tl => new Models.DTO.TheLoai
            {
                ID = tl.ID,
                TenTheLoai = tl.TenTheLoai
            }).ToList();
            return Ok(list_theloai);
        }
        public IHttpActionResult GetTheLoaiById(int id)
        {
            TheLoai theloai = db.TheLoais.Where(m => m.ID == id).First();
            WEBAPI.Models.DTO.TheLoai tl = new Models.DTO.TheLoai() {
                ID = theloai.ID,
                TenTheLoai = theloai.TenTheLoai
            };
            return Ok(tl);
        }
        public IHttpActionResult PostTheLoai(WEBAPI.Models.DTO.TheLoai newtl)
        {
            TheLoai tl = new TheLoai() {
                ID = newtl.ID,
                TenTheLoai = newtl.TenTheLoai
            };
            db.TheLoais.Add(tl);
            db.SaveChanges();
            return Ok();
        }
        public IHttpActionResult DeleteTheLoai(int id)
        {
            TheLoai tl = db.TheLoais.Where(m => m.ID == id).First();
            db.TheLoais.Remove(tl);
            db.SaveChanges();
            return Ok();
        }
        public IHttpActionResult PutTheLoai(WEBAPI.Models.DTO.TheLoai editl)
        {
            TheLoai tl = db.TheLoais.Find(editl.ID);
            tl.TenTheLoai = editl.TenTheLoai;
            db.SaveChanges();
            return Ok(); 
        }
    }
}
