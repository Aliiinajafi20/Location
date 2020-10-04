using Location.Data;
using Location.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Location.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _db;
        public CountryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(Country entity)
        {
            _db.Countries.Add(entity);
            return Save();
                
        }

        public bool Delete(Country entity)
        {
            _db.Countries.Remove(entity);
            return Save();
        }

        public ICollection<Country> FindAll()
        {
            var Countries = _db.Countries.ToList();
            return Countries;
        }

        public Country FindById(int id)
        {
            var Countries = _db.Countries.Find(id);
            return Countries;
        }

        public bool isExists(int id)
        {
            var exists = _db.Countries.Any(c => c.CountryId == id);
            return exists;
        }

        public bool Save()
        {
           var change = _db.SaveChanges();
            return change > 0;
        }

        public bool Update(Country entity)
        {
            _db.Countries.Update(entity);
            return Save();
        }
    }
}
