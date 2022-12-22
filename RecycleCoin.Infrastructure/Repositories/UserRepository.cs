using Microsoft.Extensions.Logging;
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
        public UserRepository(RecycleCoinDbContext context,ILogger logger) : base(context, logger)
        {

        }

        public User Login(string mail, string password)
        {
            var checkMail = _dbSet.FirstOrDefault(x => x.Mail == mail);
            return checkMail!;
        }
    }
}
