using System;

namespace WEBAPI.Models.DTO
{
    public class ChiTietDonHang
    {
        public int ID { get; set; }
        public Nullable<int> ID_DonHang { get; set; }
        public Nullable<int> ID_Sach { get; set; }
        public Nullable<int> SoLuongMua { get; set; }
        public Nullable<double> TongTien { get; set; }
    }
}