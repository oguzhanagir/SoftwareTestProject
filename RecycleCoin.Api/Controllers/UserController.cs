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
        
        public IUserService? _userService { get; set; }

        public UserController(IUserService? userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var users = await _userService.GetUsers();

            return users;
        }

        [HttpPost]
        public async Task AddUser(User user)
        {
            await _userService.AddUser(user);
        }

        [HttpDelete]
        public void DeleteUser(int id)
        {
            _userService.DeleteUser(id);

        }

        [HttpPut]
        public IActionResult UpdateUser(int id )
        {
            _userService.UpdateUser(id);
           return Ok();
        }

        [HttpGet("{id}")]
        public User? GetUser(int id) 
        {
            var user = _userService.GetUser(id);

            return user;
            
        }




    }
}
