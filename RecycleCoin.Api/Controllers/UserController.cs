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
            var users = await UserService!.GetUsers();
            return users;
        }

     
        [HttpGet("{id}")]
        public User? GetUser(int id) 
        {
            var user = UserService!.GetUser(id);
            return user;
        }


        [HttpPut]
        public IActionResult UpdateUser(int id )
        {
            UserService!.UpdateUser(id);
           return Ok("Kullanıcı Güncellendi");
        }


        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            UserService!.DeleteUser(id);
            return Ok("Kullanıcı Silindi");
        }



    }
}
