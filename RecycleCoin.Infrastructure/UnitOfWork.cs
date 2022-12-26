using Microsoft.Extensions.Logging;
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
        private readonly ILogger _logger;

        public UnitOfWork(RecycleCoinDbContext context,ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("logs");
            _context = context;
            Users = new UserRepository(_context,_logger);
            Category = new CategoryRepository(_context, _logger);
            Products = new ProductRepository(_context, _logger);
            Sales = new SaleRepository(_context,_logger);
            Balances = new BalanceRepository(_context,_logger);


        }

        public IUserRepository Users { get; private set; }

        public ICategoryRepository Category { get; private set; }

        public IProductRepository Products { get; private set; }

        public ISaleRepository Sales { get; private set; }

        public IBalanceRepository Balances { get; private set; }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
