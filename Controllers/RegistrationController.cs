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
        public int Register(string login, string password)
        {
            var existing = _userService.GetUsers().FirstOrDefault(user => user.Login == login);
            if (existing == null)
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                var u = new User
                {
                    Login = login,
                    Password = password
                };
                _userService.Insert(u);
                var user = _userService.GetUsers().FirstOrDefault(i => i.Login == login);
                if (user != null)
                {
                    Console.WriteLine("New User: " + user.ToString());
                    return user.Id;
                }
            }
            else
            {
                Console.WriteLine(existing.ToString());
                HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            return 0;
        }

        public IActionResult Registration()
        {
            return View();
        }
    }
}