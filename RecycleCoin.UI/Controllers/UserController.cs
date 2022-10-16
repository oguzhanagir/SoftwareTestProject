using Microsoft.AspNetCore.Mvc;
using RecycleCoin.Core;

namespace RecycleCoin.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllUsers()
        {
            var userList = _unitOfWork.Users.GetAll();
            if (userList == null)
            {
                return NotFound();
            }
            return View(userList);
        }


    }
}
