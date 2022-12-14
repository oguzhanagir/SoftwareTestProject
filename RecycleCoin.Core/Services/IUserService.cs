using FluentValidation.Results;
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
        User? GetUser(long id);

        Task<IEnumerable<User>> GetUsers();

        Task<ValidationResult?> AddUser(User user);

        void UpdateUser(long id);

        void DeleteUser(long id);

        void SaveUser();
    }
}
