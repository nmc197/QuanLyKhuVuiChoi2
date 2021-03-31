using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyKhuVuiChoi2.Models
{
    public partial class Khutrochoi
    {
        public Khutrochoi()
        {
            Dichvus = new HashSet<Dichvu>();
            Nhanviens = new HashSet<Nhanvien>();
            Trochois = new HashSet<Trochoi>();
            Ves = new HashSet<Ve>();
        }

        public string MaKhu { get; set; }
        public string TenKhu { get; set; }
        public string MaNvql { get; set; }
        public decimal? GiaVeTreEm { get; set; }
        public decimal? GiaVeNguoiLon { get; set; }

        public virtual Nhanvien MaNvqlNavigation { get; set; }
        public virtual ICollection<Dichvu> Dichvus { get; set; }
        public virtual ICollection<Nhanvien> Nhanviens { get; set; }
        public virtual ICollection<Trochoi> Trochois { get; set; }
        public virtual ICollection<Ve> Ves { get; set; }
    }
}
