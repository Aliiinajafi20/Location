using Location.Data;
using Location.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Location.Repository
{
    public class AreaRepository : IAreaRepository
    {
        private readonly ApplicationDbContext _db;
        public AreaRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(Area entity)
        {
            _db.Areas.Add(entity);
            return Save();
        }

        public bool Delete(Area entity)
        {
            _db.Areas.Remove(entity);
            return Save();
        }

        public ICollection<Area> FindAll()
        {
            var Area = _db.Areas
                 .Include(c => c.Country)
                 .ToList();
            return Area;
        }

        public Area FindById(int id)
        {
            var Area = _db.Areas
                .Include(c => c.Country)
                .FirstOrDefault(a => a.AriaId == id);
            return Area;
        }

        public bool isExists(int id)
        {
            var exists = _db.Areas.Any(a => a.AriaId == id);
            return exists;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(Area entity)
        {
            _db.Update(entity);
            return Save();

        }
    }
}
