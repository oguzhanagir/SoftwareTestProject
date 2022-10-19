using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecycleCoin.Core.Models;
using RecycleCoin.Core.Repositories;

namespace RecycleCoin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork { get; }

        [HttpGet]
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var userList = await UnitOfWork.User.GetAll();

            return userList;
        } 
    }
}
