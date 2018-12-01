using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPI.Models.DTO
{
    public class NguoiDung
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public string SDT { get; set; }
        public string Avatar { get; set; }
        public string DiaChi { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
    }
}