using RecycleCoin.Core;
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
        private readonly RecycleCoinDbContext _context;
        private UserRepository _userRepository;

        public UnitOfWork(RecycleCoinDbContext context,UserRepository userRepository)
        {
            this._context = context;
            this._userRepository = userRepository;
            
        }

        public IUserRepository Users => _userRepository = _userRepository ?? new UserRepository(_context);
    }
}
