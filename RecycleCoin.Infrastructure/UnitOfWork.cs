using RecycleCoin.Core.Repositories;
using RecycleCoin.Infrastructure.Concrete;
using RecycleCoin.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Infrastructure
{
    public class UnitOfWork: IUnitOfWork
    {
        private RecycleCoinDbContext _context;

        public UnitOfWork(RecycleCoinDbContext context)
        {
            _context = context;
            User = new UserRepository(this._context);
        }

        public IUserRepository User { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
