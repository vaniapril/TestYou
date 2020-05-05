using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TestYou.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly ILogger<RegistrationController> _logger;

        public RegistrationController(ILogger<RegistrationController> logger)
        {
            _logger = logger;
        }

        public IActionResult Registration()
        {
            return View();
        }
    }
}