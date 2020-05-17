using System;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestYou.Services;
using TestYou.Services.Models.User;

namespace TestYou.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly ILogger<RegistrationController> _logger;
        private readonly UserService _userService;

        public RegistrationController(ILogger<RegistrationController> logger)
        {
            _logger = logger;
            _userService = new UserService();
        }
        
        [HttpPost]
        public void Register(string login, string password)
        {
            var isExist = false;
            foreach (var user in _userService.GetUsers().Where(user => user.Login == login))
            {
                isExist = true;
            }

            if (!isExist)
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                var u = new User
                {
                    Login = login,
                    Password = password
                };
                Console.WriteLine("New User: " + u.ToString());
                _userService.Insert(u);
            }
            else
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
        }

        public IActionResult Registration()
        {
            return View();
        }
    }
}