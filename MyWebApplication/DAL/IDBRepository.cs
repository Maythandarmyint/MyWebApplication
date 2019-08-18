using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApplication.DAL
{
    public interface IDBRepository<T> where T : class
    {
        int Add(T t);
        bool Delete(object key);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        T FindSingle(Expression<Func<T, bool>> predicate);
        T Get(int id);
        IQueryable<T> GetAll();
        bool Update(T t, object key);
    }
}
