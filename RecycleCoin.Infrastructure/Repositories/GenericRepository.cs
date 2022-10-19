using Microsoft.EntityFrameworkCore;
using RecycleCoin.Core.Repositories;
using RecycleCoin.Infrastructure.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Infrastructure.Repositories
{
    public class GenericRepository<T>:IGenericRepository<T> where T: class
    {
        protected readonly RecycleCoinDbContext _context;
        internal DbSet<T> dbSet;


        public GenericRepository(RecycleCoinDbContext context)
        {
            this._context = context;
            this.dbSet = context.Set<T>();
        }

        public async Task Add(T entity)
        {
           await dbSet.AddAsync(entity);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public ValueTask<T?> GetById(int id)
        {
            return dbSet.FindAsync(id);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }
    }
}
