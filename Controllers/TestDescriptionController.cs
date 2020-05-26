using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestYou.Services;
using TestYou.Services.Models.Test;
using TestYou.Services.Models.User;

namespace TestYou.Controllers
{
    public class TestDescriptionController : Controller
    {
        private readonly ILogger<TestDescriptionController> _logger;
        private readonly TestService _testService;
        private readonly UserService _userService;
        
        public TestDescriptionController(ILogger<TestDescriptionController> logger)
        {
            _logger = logger;
            _testService = new TestService();
            _userService = new UserService();
        }
        [HttpGet]
        public Test Get(int id)
        {
            return _testService.GetById(id);
        }
        [HttpPost]
        public void Delete(int id)
        {
            _testService.DeleteById(id);
        }
        [HttpGet]
        public List<User> GetUsers()
        {
            var users = _userService.GetUsers();
            users.ForEach(user => { user.Password = "";});
            return users;
        }
        
        public IActionResult  TestDescription(int id)
        {
            var test = _testService.GetById(id);
            ViewBag.Title = test.Title;
            ViewBag.Id = test.Id;
            ViewBag.Description = test.Description;
            return View();
        }
    }
}