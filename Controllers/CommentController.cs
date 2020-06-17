using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestYou.Services;
using TestYou.Services.Models.Test;

namespace TestYou.Controllers
{
    public class CommentController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TestService _testService;

        public CommentController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _testService = new TestService();
        }

        [HttpPost]
        public int Add(Comment comment)
        {
            Console.WriteLine("New Comment:" + comment.ToString());
            _testService.InsertComment(comment);
            return 0;
        }

        [HttpGet]
        public Test Get(int id)
        {
            return _testService.GetById(id);
        }

        public IActionResult Comment(int id)
        {
            ViewBag.testId = id;
            return View();
        }
    }
}