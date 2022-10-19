using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Core.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }
        int Save();

    }
}
