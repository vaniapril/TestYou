using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestYou.Services;
using TestYou.Services.Models.Test;

namespace TestYou.Controllers
{
    public class TestDescriptionController : Controller
    {
        private readonly ILogger<TestDescriptionController> _logger;
        private readonly TestService _testService;
        
        public TestDescriptionController(ILogger<TestDescriptionController> logger)
        {
            _logger = logger;
            _testService = new TestService();
        }
        [HttpGet]
        public Test Get(int id)
        {
            return _testService.GetById(id);
        }
        
        public IActionResult  TestDescription()
        {
            return View();
        }
    }
}