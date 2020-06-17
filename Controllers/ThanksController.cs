using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TestYou.Controllers
{
    public class ThanksController: Controller
    {
        private readonly ILogger<ThanksController> _logger;

        public ThanksController(ILogger<ThanksController> logger)
        {
            _logger = logger;
        }

        public IActionResult Thanks()
        {
            return View();
        }
    }
}
