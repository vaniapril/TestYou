using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TestYou.Controllers
{
    public class TestDescriptionController : Controller
    {
        private readonly ILogger<TestDescriptionController> _logger;

        public TestDescriptionController(ILogger<TestDescriptionController> logger)
        {
            _logger = logger;
        }

        public IActionResult  TestDescription()
        {
            return View();
        }
    }
}