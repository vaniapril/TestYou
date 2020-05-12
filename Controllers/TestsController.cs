using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestYou.Services;
using TestYou.Services.Models.Test;

namespace TestYou.Controllers
{
    public class TestsController : Controller
    {
        private readonly ILogger<TestsController> _logger;
        private readonly TestService _testService;
        public TestsController(ILogger<TestsController> logger)
        {
            _logger = logger;
            _testService = new TestService();
        }
        [HttpPost]
        public void AddTest()
        {
            Test test = new Test
            {
                Id = 1,
                Title = "arw",
                Description = "der",
                UserId = 3
            };
            Console.WriteLine("Add test: " + test.ToString());
            _testService.AddTest(test);
        }

        [HttpGet]
        public List<Test> GetTests()
        {
            return _testService.GetTests();
        }
        
        public IActionResult  Tests()
        {
            return View();
        }
    }
}