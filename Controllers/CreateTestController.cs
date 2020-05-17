using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestYou.Services;
using TestYou.Services.Models.Test;

namespace TestYou.Controllers
{
    public class CreateTestController : Controller
    {
        private readonly ILogger<CreateTestController> _logger;
        private readonly TestService _testService;

        public CreateTestController(ILogger<CreateTestController> logger)
        {
            _logger = logger;
            _testService = new TestService();
        }

        [HttpPost]
        public void CreateTestPost(Test test)
        {
            Console.WriteLine(test.ToString());
            _testService.AddTest(test);
        }
        
        public IActionResult  CreateTest()
        {
            return View();
        }
    }
}