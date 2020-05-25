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
        public TestPassingController(ILogger<TestPassingController> logger)
        {
            _logger = logger;
            _resultService = new ResultService();
        }
        [HttpPost]
        public void Pass(Result result)
        {
            _resultService.Insert(result);
        }

        public IActionResult TestPassing()
        {
            return View();
        }
    }
}