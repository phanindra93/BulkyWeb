using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;

namespace Bulky.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private  ApplicationDbContext _db;
        internal Microsoft.EntityFrameworkCore.DbSet<T> dbSet; 
        public Repository(ApplicationDbContext db)
        {
            _db= db;
            this.dbSet = _db.Set<T>();
            /*
             * Set<T>() Method: The Set<T>() method is a method provided by Entity Framework Core's DbContext class,
             * which ApplicationDbContext inherits from. 
             * This method returns a DbSet<T> object representing the table in the database that corresponds to the entity type T.
             */
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }

        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query=dbSet.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }
    }
}
