using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyKhuVuiChoi2.Models
{
    public partial class Thietbi
    {
        public string MaTb { get; set; }
        public string TenTb { get; set; }
        public string MaTroChoi { get; set; }
        public string TinhTrang { get; set; }

        public virtual Trochoi MaTroChoiNavigation { get; set; }
    }
}
