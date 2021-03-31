using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyKhuVuiChoi2.Models
{
    public partial class Dichvu
    {
        public Dichvu()
        {
            Chitiethoadons = new HashSet<Chitiethoadon>();
        }

        public string MaDv { get; set; }
        public string TenDv { get; set; }
        public int? Gia { get; set; }
        public string MaKhu { get; set; }

        public virtual Khutrochoi MaKhuNavigation { get; set; }
        public virtual ICollection<Chitiethoadon> Chitiethoadons { get; set; }
    }
}
