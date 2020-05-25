using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestYou.Services;
using TestYou.Services.Models.Result;

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
        public void Pass(Result result)
        {
            _resultService.Insert(result);
        }

        public IActionResult TestPassing(int id)
        {
            ViewBag.test = _testService.GetById(id);
            return View();
        }
    }
}