using System;
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
        public void RegisterPost(string login, string password)
        {
            var user = new User
            {
                Id = 1,
                Login = login,
                Password = password
            };
            Console.WriteLine("New User: " + user.ToString());
            _userService.Insert(user);
        }

        public IActionResult Registration()
        {
            return View();
        }
    }
}