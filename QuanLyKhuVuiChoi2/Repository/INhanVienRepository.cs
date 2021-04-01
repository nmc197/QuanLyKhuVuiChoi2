using QuanLyKhuVuiChoi2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyKhuVuiChoi2.Repository
{
    public interface INhanVienRepository
    {
        Task<List<Nhanvien>> List();

        Task<List<Nhanvien>> Detail(int? id);
        Task<Nhanvien> Add(Nhanvien obj);
        Task Update(Nhanvien obj);
        Task<int> Delete(string id);
        Task<List<Nhanvien>> Search(string keyword);
    }
}
