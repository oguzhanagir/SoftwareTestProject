using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Core.Repositories
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        ValueTask<T?> GetById(int id);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        Task Add(T entity);
        void Remove(T entity);

        void Update(T entity);


    }
}
