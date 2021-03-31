using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyKhuVuiChoi2.Models
{
    public partial class Khachhang
    {
        public Khachhang()
        {
            Hoadons = new HashSet<Hoadon>();
            Ves = new HashSet<Ve>();
        }

        public string MaKh { get; set; }
        public string TenKh { get; set; }
        public int? TuoiKh { get; set; }
        public string GioTinhKh { get; set; }

        public virtual ICollection<Hoadon> Hoadons { get; set; }
        public virtual ICollection<Ve> Ves { get; set; }
    }
}
