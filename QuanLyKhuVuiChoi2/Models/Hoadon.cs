using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyKhuVuiChoi2.Models
{
    public partial class Hoadon
    {
        public string MaHd { get; set; }
        public string NgayHd { get; set; }
        public string MaKh { get; set; }

        public virtual Khachhang MaKhNavigation { get; set; }
        public virtual Chitiethoadon Chitiethoadon { get; set; }
    }
}
