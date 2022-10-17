using RecycleCoin.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Core.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        List<User> GetUserById(int id);
        void CreateUser(User user);
        int UpdateUser(User userToBeUpdated, User user);
        int DeleteUser(User user);
    }
}
