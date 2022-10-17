using Microsoft.Extensions.Logging;
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
        private readonly ILogger _logger;


        public IUserRepository Users { get; private set; }

        public UnitOfWork(RecycleCoinDbContext context, ILoggerFactory loggerFactory)
        {
            this._context = context;
            _logger = loggerFactory.CreateLogger("logs");
            Users = new UserRepository(context, _logger);

        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
