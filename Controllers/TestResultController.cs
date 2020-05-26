using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestYou.Services;
using TestYou.Services.Models.Result;
using TestYou.Services.Models.Test;

namespace TestYou.Controllers
{
    public class TestResultController : Controller
    {
        private readonly ILogger<TestPassingController> _logger;
        private readonly TestService _testService;
        public TestResultController(ILogger<TestPassingController> logger)
        {
            _logger = logger;
            _testService = new TestService();
        }
        [HttpGet]
        public TestResult Get(int testId, int id)
        {
            return _testService.GetById(testId).Results.First(result => result.Id == id);
        }

        public IActionResult TestResult(int testId, int id)
        {
            ViewBag.id = id;
            ViewBag.testId = testId;
            return View();
        }
    }
}