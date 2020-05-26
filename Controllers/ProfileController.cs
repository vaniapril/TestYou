using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestYou.Services;
using TestYou.Services.Models.Test;
using TestYou.Services.Models.User;

namespace TestYou.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ILogger<ProfileController> _logger;
        private readonly UserService _userService;
        private readonly TestService _testService;
        
        public ProfileController(ILogger<ProfileController> logger)
        {
            _logger = logger;
            _userService = new UserService();
            _testService = new TestService();
        }

        [HttpGet]
        public User GetUser(int id)
        {
            return _userService.GetUserById(id);
        }
        
        [HttpGet]
        public List<Test> GetUserTests(int id)
        {
            Console.WriteLine(id);
            return _testService.GetByUserId(id);
        }
        
        public IActionResult Profile()
        {
            return View();
        }
    }
}