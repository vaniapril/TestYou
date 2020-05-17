using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TestYou.Controllers
{
    public class TestPassingController : Controller
    {
        private readonly ILogger<TestPassingController> _logger;

        public TestPassingController(ILogger<TestPassingController> logger)
        {
            _logger = logger;
        }

        public IActionResult TestPassing()
        {
            return View();
        }
    }
}