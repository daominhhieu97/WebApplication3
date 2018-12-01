using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPI.Models.DTO
{
    public class DonHang
    {
        public int MaDonHang { get; set; }
        public Nullable<int> ID_NguoiMua { get; set; }
        public Nullable<double> TongTien { get; set; }
        public string DiaChiGiao { get; set; }
        public string SoDT { get; set; }
        public Nullable<System.DateTime> NgayDat { get; set; }
        public Nullable<bool> TrangThai { get; set; }
        public List<ChiTietDonHang> lst_chitiets { get; set; }
    }
}