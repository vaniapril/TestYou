using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestYou.Services;
using TestYou.Services.Models.User;

namespace TestYou.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ILogger<ProfileController> _logger;
        private readonly UserService _userService;
        
        public ProfileController(ILogger<ProfileController> logger)
        {
            _logger = logger;
            _userService = new UserService();
        }

        [HttpGet]
        public User GetUser(int id)
        {
            return _userService.GetUserById(id);
        }
        
        public IActionResult Profile()
        {
            return View();
        }
    }
}