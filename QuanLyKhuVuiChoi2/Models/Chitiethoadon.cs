using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyKhuVuiChoi2.Models
{
    public partial class Chitiethoadon
    {
        public string MaHd { get; set; }
        public string MaDv { get; set; }
        public string SoLanSuDungDv { get; set; }

        public virtual Dichvu MaDvNavigation { get; set; }
        public virtual Hoadon MaHdNavigation { get; set; }
    }
}
