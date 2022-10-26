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
            Users = new UserRepository(_context);
            Category = new CategoryRepository(_context);
            Products = new ProductRepository(_context);
            Sales = new SaleRepository(_context);


        }

        public IUserRepository Users { get; private set; }

        public ICategoryRepository Category { get; private set; }

        public IProductRepository Products { get; private set; }

        public ISaleRepository Sales { get; private set; }

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
