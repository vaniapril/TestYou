using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestYou.Services;
using TestYou.Services.Models.Result;
using TestYou.Services.Models.Test;

namespace TestYou.Controllers
{
    public class TestPassingController : Controller
    {
        private readonly ILogger<TestPassingController> _logger;
        private readonly ResultService _resultService;
        private readonly TestService _testService;
        public TestPassingController(ILogger<TestPassingController> logger)
        {
            _logger = logger;
            _resultService = new ResultService();
            _testService = new TestService();
        }
        [HttpPost]
        public int Pass(Result result)
        {
            Console.WriteLine("New Result:" + result.ToString());
            _resultService.Insert(result);
            return 0;
        }
        [HttpGet]
        public Test Get(int id)
        {
            return _testService.GetById(id);
        }

        public IActionResult TestPassing(int id)
        {
            var test = _testService.GetById(id);
            ViewBag.Id = test.Id;
            ViewBag.Title = test.Title;
            return View();
        }
    }
}