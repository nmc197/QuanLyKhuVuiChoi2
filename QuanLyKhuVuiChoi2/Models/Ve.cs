using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyKhuVuiChoi2.Models
{
    public partial class Ve
    {
        public string MaVe { get; set; }
        public string MaKh { get; set; }
        public string MaKhu { get; set; }
        public string NgayPhatHanh { get; set; }

        public virtual Khachhang MaKhNavigation { get; set; }
        public virtual Khutrochoi MaKhuNavigation { get; set; }
    }
}
