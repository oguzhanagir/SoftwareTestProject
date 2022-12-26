using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger _logger;
        internal DbSet<T> _dbSet;


        public GenericRepository(RecycleCoinDbContext context,ILogger logger)
        {
            _logger = logger;
            this._context = context;
            this._dbSet = context.Set<T>();
        }

        public void Add(T entity)
            => _dbSet.Add(entity);


        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
            => await _dbSet.AddAsync(entity);
        public T? Find(Expression<Func<T, bool>> where)
        {
            return _dbSet.FirstOrDefault(where);
        }

        public void AddRange(IEnumerable<T> entities)
            => _dbSet.AddRange(entities);


        public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
            => await _dbSet.AddRangeAsync(entities);


        public T? Get(Expression<Func<T, bool>> expression)
        {
            return _dbSet.FirstOrDefault(expression);
        }
        public IEnumerable<T> GetList(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression).AsEnumerable();
        }


        public IEnumerable<T> GetAll()
            => _dbSet.AsEnumerable();


        public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression)
            => _dbSet.Where(expression).AsEnumerable();


        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
            => await _dbSet.ToListAsync(cancellationToken);


        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
            => await _dbSet.Where(expression).ToListAsync(cancellationToken);


        public async Task<T?> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
            => await _dbSet.FirstOrDefaultAsync(expression);


        public void Remove(T entity)
            => _dbSet.Remove(entity);


        public void RemoveRange(IEnumerable<T> entities)
            => _dbSet.RemoveRange(entities);


        public void Update(T entity)
            => _dbSet.Update(entity);


        public void UpdateRange(IEnumerable<T> entities)
            => _dbSet.UpdateRange(entities);
    }
}
