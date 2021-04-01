using Microsoft.EntityFrameworkCore;
using QuanLyKhuVuiChoi2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyKhuVuiChoi2.Repository
{
    public class NhanVienRepository: INhanVienRepository
    {
        AmusementParkContext db;
        public NhanVienRepository(AmusementParkContext _db)
        {
            db = _db;
        }
        public async Task<List<Nhanvien>> List()
        {
            if (db != null)
            {
                return await (
                    from row in db.Nhanviens
                    orderby row.MaNv descending
                    select row
                ).ToListAsync();
            }

            return null;
        }
        public async Task<List<Nhanvien>> Detail(int? id)
        {
            if (db != null)
            {
                return await (
                    from row in db.Nhanviens
                    select row)
                .ToListAsync();
            }

            return null;
        }

        public async Task<Nhanvien> Add(Nhanvien obj)
        {
            if (db != null)
            {
                await db.Nhanviens.AddAsync(obj);
                await db.SaveChangesAsync();

                return obj;
            }

            return null;
        }


        public async Task Update(Nhanvien obj)
        {
            if (db != null)
            {
                //Update that object
                db.Nhanviens.Attach(obj);
                // db.Entry(obj).Property(x => x.Name).IsModified = true;
                // db.Entry(obj).Property(x => x.Description).IsModified = true;
                // db.Entry(obj).Property(x => x.Active).IsModified = true;
                db.Entry(obj).Property(x => x.MaNv).IsModified = true;
                db.Entry(obj).Property(x => x.TenNv).IsModified = true;
                db.Entry(obj).Property(x => x.NgaySinh).IsModified = true;
                db.Entry(obj).Property(x => x.GioiTinh).IsModified = true;
                db.Entry(obj).Property(x => x.MaKhuPhuTrach).IsModified = true;
                db.Entry(obj).Property(x => x.MaPb).IsModified = true;
                db.Entry(obj).Property(x => x.Luong).IsModified = true;
                db.Entry(obj).Property(x => x.QueQuan).IsModified = true;

                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }


        public async Task<int> Delete(string id)
        {
            int result = 0;
            if (db != null)
            {
                var obj = await db.Nhanviens.FirstOrDefaultAsync(x => x.MaNv == id);
                //Update that obj
                if (obj != null)
                {
                    //Delete that post
                    db.Nhanviens.Remove(obj);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }

                //Commit the transaction
                return result;
            }
            return result;
        }
        public async Task<List<Nhanvien>> Search(string keyword)
        {
            if (db != null)
            {
                return await (
                    from row in db.Nhanviens
                    where ((row.TenNv.Contains(keyword) || row.MaNv.Contains(keyword)))
                    orderby row.MaNv descending
                    select row
                ).ToListAsync();
            }

            return null;
        }
    }
}
