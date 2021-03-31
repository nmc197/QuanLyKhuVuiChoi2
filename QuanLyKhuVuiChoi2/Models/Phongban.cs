using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyKhuVuiChoi2.Models
{
    public partial class Phongban
    {
        public string MaPb { get; set; }
        public string TenPb { get; set; }
        public string MaTp { get; set; }
        public DateTime? NgayNc { get; set; }
        public string DiaDiem { get; set; }

        public virtual Nhanvien MaTpNavigation { get; set; }
        public virtual Nhanvien Nhanvien { get; set; }
    }
}
