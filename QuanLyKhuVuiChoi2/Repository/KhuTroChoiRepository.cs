using Microsoft.EntityFrameworkCore;
using QuanLyKhuVuiChoi2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyKhuVuiChoi2.Repository
{
    public class KhuTroChoiRepository : IKhuTroChoiRepository
    {
        AmusementParkContext db;
        public KhuTroChoiRepository(AmusementParkContext _db)
        {
            db = _db;
        }
        public async Task<List<Khutrochoi>> List()
        {
            if (db != null)
            {
                return await (
                    from row in db.Khutrochois
                    orderby row.MaKhu descending
                    select row
                ).ToListAsync();
            }

            return null;
        }
        public async Task<List<Khutrochoi>> Detail(int? id)
        {
            if (db != null)
            {
                return await (
                    from row in db.Khutrochois
                    select row)
                .ToListAsync();
            }

            return null;
        }

        public async Task<Khutrochoi> Add(Khutrochoi obj)
        {
            if (db != null)
            {
                await db.Khutrochois.AddAsync(obj);
                await db.SaveChangesAsync();

                return obj;
            }

            return null;
        }


        public async Task Update(Khutrochoi obj)
        {
            if (db != null)
            {
                //Update that object
                db.Khutrochois.Attach(obj);
                // db.Entry(obj).Property(x => x.Name).IsModified = true;
                // db.Entry(obj).Property(x => x.Description).IsModified = true;
                // db.Entry(obj).Property(x => x.Active).IsModified = true;
                db.Entry(obj).Property(x => x.MaKhu).IsModified = true;
                db.Entry(obj).Property(x => x.TenKhu).IsModified = true;
                db.Entry(obj).Property(x => x.MaNvql).IsModified = true;
                db.Entry(obj).Property(x => x.GiaVeTreEm).IsModified = true;
                db.Entry(obj).Property(x => x.GiaVeNguoiLon).IsModified = true;
                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }


        public async Task<int> Delete(string id)
        {
            int result = 0;
            if (db != null)
            {
                var obj = await db.Khutrochois.FirstOrDefaultAsync(x => x.MaKhu == id);
                //Update that obj
                if (obj != null)
                {
                    //Delete that post
                    db.Khutrochois.Remove(obj);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }

                //Commit the transaction
                return result;
            }
            return result;
        }
        public async Task<List<Khutrochoi>> Search(string keyword)
        {
            if (db != null)
            {
                return await (
                    from row in db.Khutrochois
                    where ((row.TenKhu.Contains(keyword) || row.MaKhu.Contains(keyword)))
                    orderby row.MaKhu descending
                    select row
                ).ToListAsync();
            }

            return null;
        }
    }
}
