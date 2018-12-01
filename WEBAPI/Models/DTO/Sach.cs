using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPI.Models.DTO
{
    public class Sach
    {
        public int ID { get; set; }
        public string TenSach { get; set; }
        public Nullable<double> Gia { get; set; }
        public Nullable<int> SoTrang { get; set; }
        public string Anhbia { get; set; }
    }
}