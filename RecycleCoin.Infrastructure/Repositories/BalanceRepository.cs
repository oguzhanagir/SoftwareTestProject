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
    public class BalanceRepository : GenericRepository<Balance>, IBalanceRepository
    {
        public BalanceRepository(RecycleCoinDbContext context, ILogger logger) : base(context, logger)
        {

        }

       
    }
}
