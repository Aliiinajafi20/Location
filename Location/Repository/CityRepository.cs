using Location.Data;
using Location.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Location.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly ApplicationDbContext _db;
        public CityRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(City entity)
        {
            _db.Cities.Add(entity);
            return Save();
        }

        public bool Delete(City entity)
        {
            _db.Cities.Remove(entity);
            return Save();
        }

        public ICollection<City> FindAll()
        {
            var City = _db.Cities
                .Include(a => a.Area)
                .Include(c => c.Area.Country)
                .ToList();
            return City;
        }

        public City FindById(int id)
        {
            var City = _db.Cities
                   .Include(c => c.Area.Country)
                   .Include(a => a.Area)
                   .FirstOrDefault(Y => Y.CityId == id);
            return City;
        }

        public bool isExists(int id)
        {
            var exists = _db.Cities.Any(c => c.CityId == id);
            return exists;


        }

        public bool Save()
        {
          var change = _db.SaveChanges();
            return change > 0;
        }

        public bool Update(City entity)
        {
            _db.Cities.Update(entity);
            return Save();
        }
    }
}
