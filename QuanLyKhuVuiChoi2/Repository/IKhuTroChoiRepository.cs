using QuanLyKhuVuiChoi2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuanLyKhuVuiChoi2.Repository
{
    public interface IKhuTroChoiRepository
    {
        Task<List<Khutrochoi>> List();

        Task<List<Khutrochoi>> Detail(int? id);
        Task<Khutrochoi> Add(Khutrochoi obj);
        Task Update(Khutrochoi obj);
        Task<int> Delete(string id);
        Task<List<Khutrochoi>> Search(string keyword);
    }
}
