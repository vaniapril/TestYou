using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TestYou.Controllers
{
    public class QuestionController : Controller
    {
        private readonly ILogger<QuestionController> _logger;

        public QuestionController(ILogger<QuestionController> logger)
        {
            _logger = logger;
        }

        public IActionResult Question()
        {
            return View();
        }
    }
}