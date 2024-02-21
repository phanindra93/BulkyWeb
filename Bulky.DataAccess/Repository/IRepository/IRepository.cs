using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class //now we might be working with categories but down the line we might have different classes - product,order etc thats why generic
    {
        IEnumerable<T> GetAll();
        // 
        T Get(Expression<Func<T, bool>> filter);// if you wanna deal with one object of class use T as return type In the context of your provided data and scenario, if you had a method T GetAll() returning a single Product object, the output would be limited to just one Product instance.
        void Add(T entity);
      // we dont wanna add update coz in many situations we nly update few props
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entity);
    }
}
