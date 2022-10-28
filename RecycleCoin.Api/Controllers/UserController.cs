using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecycleCoin.Core.Models;
using RecycleCoin.Core.Repositories;
using RecycleCoin.Core.Services;
using RecycleCoin.Infrastructure.Concrete;

namespace RecycleCoin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        public IUserService? UserService { get; set; }

        public UserController(IUserService? userService)
        {
            UserService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            
            var users = await UserService.GetUsers();

            return users;
        }

        [HttpPost]
        public async Task AddUser(User user)
        {
            await UserService.AddUser(user);
        }

        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            UserService.DeleteUser(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateUser(int id )
        {
            UserService.UpdateUser(id);
           return Ok();
        }

        [HttpGet("{id}")]
        public User? GetUser(int id) 
        {
            var user = UserService.GetUser(id);
            return user;
            
        }




    }
}
