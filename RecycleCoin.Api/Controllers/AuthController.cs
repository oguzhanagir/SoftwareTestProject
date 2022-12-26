using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RecycleCoin.Core.Models;
using RecycleCoin.Core.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace RecycleCoin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IUserService? UserService { get; set; }
        public readonly User user;
        private readonly IConfiguration _configuration;
        public AuthController(IUserService? userService,IConfiguration configuration)
        {
            user = new User(); 
            UserService = userService;
            _configuration = configuration;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register(UserDto userDto)
        {
            CreatePasswordHash(userDto.Password!, out byte[] passwordHash, out byte[] passwordSalt);

            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.Mail = userDto.Mail;
            user.ShaAddress = System.Text.Encoding.UTF8.GetBytes(user.Mail!);
            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;

            var message = await UserService!.AddUser(user);

            return Ok(message!.Errors);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<User>> Login(string mail, string password)
        {
            var userCheck =  UserService!.Login(mail, password);
                
            if (userCheck == null)
            {
                return BadRequest("Kullanıcı Bulunamadı");
            }

            var passwordCheck = VerifyPasswordHash(password!, userCheck!.PasswordHash!, userCheck.PasswordHash!);

            

            if (!passwordCheck)
            {
                return BadRequest("Yanlış Şifre");
            }

            string token = CreateToken(userCheck);



            return Ok(token);
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Mail!)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration
                .GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);


            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA256())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA256(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private byte[] ShaAddress(string mail)
        {
            using (var hmac = new HMACSHA256())
            {
                
                return hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(mail));

            }
        }
    }
}
