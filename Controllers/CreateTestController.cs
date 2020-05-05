using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TestYou.Controllers
{
    public class CreateTestController : Controller
    {
        private readonly ILogger<CreateTestController> _logger;

        public CreateTestController(ILogger<CreateTestController> logger)
        {
            _logger = logger;
        }

        public IActionResult  CreateTest()
        {
            return View();
        }
    }
}