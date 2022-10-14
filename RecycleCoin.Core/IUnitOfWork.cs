using RecycleCoin.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Core
{
    public class IUnitOfWork : IDisposable
    {
        IUserRepository? Users { get; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
