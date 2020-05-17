using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TestYou.Controllers
{
    public class TestResultController : Controller
    {
        private readonly ILogger<TestPassingController> _logger;

        public TestResultController(ILogger<TestPassingController> logger)
        {
            _logger = logger;
        }

        public IActionResult TestResult()
        {
            return View();
        }
    }
}