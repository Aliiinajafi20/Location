using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Location.Service
{
   public interface IRepository_Base<T> where T:class
    {
        ICollection<T> FindAll();
        T FindById(int id);
        bool isExists(int id);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool Save();


    }
}
