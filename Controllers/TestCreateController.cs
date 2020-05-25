using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestYou.Services;
using TestYou.Services.Models.Test;

namespace TestYou.Controllers
{
    public class TestCreateController : Controller
    {
        private readonly ILogger<TestCreateController> _logger;
        private readonly TestService _testService;

        public TestCreateController(ILogger<TestCreateController> logger)
        {
            _logger = logger;
            _testService = new TestService();
        }

        [HttpPost]
        public int Create(Test test)
        {
            Console.WriteLine("Create Test" + test.ToString());
            _testService.Insert(test);
            return 0;
        }

        [HttpPost]
        public void Clear()
        {
            Console.WriteLine("Clear Test");
            var ts = _testService.GetAll();
            ts.ForEach(t =>
            {
                _testService.DeleteById(t.Id);
            });
        }
        
        public IActionResult  TestCreate()
        {
            return View();
        }
    }
}