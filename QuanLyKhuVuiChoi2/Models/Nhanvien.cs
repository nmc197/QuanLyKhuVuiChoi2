using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyKhuVuiChoi2.Models
{
    public partial class Nhanvien
    {
        public Nhanvien()
        {
            Khutrochois = new HashSet<Khutrochoi>();
            Phongbans = new HashSet<Phongban>();
            Trochois = new HashSet<Trochoi>();
        }

        public string MaNv { get; set; }
        public string TenNv { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string MaKhuPhuTrach { get; set; }
        public string MaPb { get; set; }
        public double? Luong { get; set; }
        public string QueQuan { get; set; }

        public virtual Khutrochoi MaKhuPhuTrachNavigation { get; set; }
        public virtual Phongban MaNvNavigation { get; set; }
        public virtual ICollection<Khutrochoi> Khutrochois { get; set; }
        public virtual ICollection<Phongban> Phongbans { get; set; }
        public virtual ICollection<Trochoi> Trochois { get; set; }
    }
}
