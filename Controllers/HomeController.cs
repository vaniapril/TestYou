using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestYou.Services;
using TestYou.Services.Models.Test;

namespace TestYou.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TestService _testService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _testService = new TestService();
        }

        [HttpGet]
        public List<Test> GetTests()
        {
            return _testService.GetAll();
        }

        public IActionResult Home()
        {
            return View();
        }
    }
}