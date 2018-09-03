using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBook.Models
{
    public class GioHang
    {
        public List<Sach> LST_SACHS { get; set; }
        public double totalprice { get; set; }
        public GioHang()
        {
            LST_SACHS = new List<Sach>();
            totalprice = 0;
        }
        internal void themsach(Sach sach)
        {
            LST_SACHS.Add(sach);
            totalprice += (double)sach.Gia;
        }

        internal void xoasach(Sach sach)
        {
            LST_SACHS.Remove(sach);
            totalprice -= (double)sach.Gia;
        }
    }
}