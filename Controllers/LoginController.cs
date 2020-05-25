using System;
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
        public int SignIn(string login, string password) 
        {
            var existing = _userService.GetUsers().FirstOrDefault(user => user.Login == login);
            if (existing != null)
            {
                if (existing.Password == password)
                {
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                    return existing.Id;
                }
                else
                {
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.Conflict;
                }
            }
            else
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            return 0;
        }
        public IActionResult Login()
        {
            return View();
        }
    }
}