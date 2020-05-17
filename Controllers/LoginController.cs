using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestYou.Services;
using TestYou.Services.Models.User;

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
        public void LoginPost(string login, string password)
        {
            Console.WriteLine(login + " / " + password);
            List<User> users = _userService.GetUsers();
            bool isExist = false;
            foreach (var user in users)
            {
                if (user.Login == login)
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