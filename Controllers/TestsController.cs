using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TestYou.Controllers
{
    public class TestsController : Controller
    {
        private readonly ILogger<TestsController> _logger;

        public TestsController(ILogger<TestsController> logger)
        {
            _logger = logger;
        }

        public IActionResult  Tests()
        {
            return View();
        }
    }
}