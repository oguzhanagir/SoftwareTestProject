using RecycleCoin.Core.Models;
using RecycleCoin.Core.Repositories;
using RecycleCoin.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Business.Concrete
{
    public class UserService: IUserService
    {

        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;

        }

        public async Task? AddUser(User user)
        {
            _unitOfWork.Users.Add(user);
            await _unitOfWork.CommitAsync();
        }

        public void DeleteUser(long id)
        {
            var user = _unitOfWork.Users.Find(x => x.Id == id);
            if (user != null)
            {
                _unitOfWork.Users.Remove(user);
                _unitOfWork.Save();
            }
        }

        public User? GetUser(long id)
        {
            var users = _unitOfWork.Users.Get(x => x.Id == id);
            if (users !=null)
            {
                return users;
            }
            
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _unitOfWork.Users.GetAllAsync();
        }

        public void SaveUser()
        {
            _unitOfWork.Save();
        }

        public void UpdateUser(long id)
        {
            var user = _unitOfWork.Users.Find(x => x.Id == id);
            if (user != null)
            {
                _unitOfWork.Users.Update(user);
                _unitOfWork.Save();
            }
        }
    }
}
