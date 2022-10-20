using RecycleCoin.Core.Models;
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
    public class UnitOfWork : IUnitOfWork
    {
        private RecycleCoinDbContext _context;

        public UnitOfWork(RecycleCoinDbContext context)
        {
            _context = context;
            Users = new UserRepository(this._context);
        }

        public IUserRepository Users { get; private set; }

   

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
