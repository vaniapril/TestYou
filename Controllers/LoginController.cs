using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestYou.Services;

namespace TestYou.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly UserService _userService;
        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
            _userService = new UserService();
        }
        [HttpPost]
        public void SignIn(string login, string password) 
        {
            var users = _userService.GetUsers();
            var isExist = false;
            foreach (var user in users.Where(user => user.Login == login))
            {
                isExist = true;
                if (user.Password == password)
                {
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                }
                else
                {
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                }
                break;
            }
            if (isExist)
            {
                HttpContext.Response.StatusCode = (int) HttpStatusCode.NotFound;
            }
        }
        public IActionResult Login()
        {
            return View();
        }
    }
}