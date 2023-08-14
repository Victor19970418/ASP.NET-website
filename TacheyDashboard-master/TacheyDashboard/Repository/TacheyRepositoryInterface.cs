using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TacheyDashboard.Repository
{
    interface TacheyRepositoryInterface<T> where T : class
    {
        IEnumerable<T> Query(string sql, object param = null);
        bool Delete(T entity);
        bool DeleteAll();
        T Get(object id);
        IEnumerable<T> GetAll();
        long Insert(T entity);
        bool Update(T entity);
    }
}
