using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestYou.Services;
using TestYou.Services.Models.Result;

namespace TestYou.Controllers
{
    public class TestResultController : Controller
    {
        private readonly ILogger<TestPassingController> _logger;
        private readonly ResultService _resultService;
        public TestResultController(ILogger<TestPassingController> logger)
        {
            _logger = logger;
            _resultService = new ResultService();
        }
        [HttpPost]
        public Result Get(int id)
        {
            return _resultService.GetById(id);
        }

        public IActionResult TestResult()
        {
            return View();
        }
    }
}