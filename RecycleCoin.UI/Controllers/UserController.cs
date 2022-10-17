using Microsoft.AspNetCore.Mvc;
using RecycleCoin.Core;

namespace RecycleCoin.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger,IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllUsers()
        {
            var userList = _unitOfWork.Users.GetAll();

            _unitOfWork.Complete();
            if (userList is not null)
            {
                return View(userList);
            }
            else
            {
                return NotFound();
            }
           
        }


    }
}
