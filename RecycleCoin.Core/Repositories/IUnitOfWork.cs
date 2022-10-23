using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Core.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        ICategoryRepository Category { get; }
        IProductRepository Products { get; }
        ISaleRepository Sales { get; }
        int Save();

    }
}
