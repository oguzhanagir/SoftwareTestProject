using RecycleCoin.Core.Models;
using RecycleCoin.Core.Repositories;
using RecycleCoin.Infrastructure.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Infrastructure.Repositories
{
    public class UserRepository: GenericRepository<User>,IUserRepository
    {
        public UserRepository(RecycleCoinDbContext context) : base(context)
        {

        }
    }
}
