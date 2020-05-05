using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestYou.Models;

namespace TestYou.Controllers
{
    public class TestingController : Controller
    {
        private readonly ILogger<TestingController> _logger;

        public TestingController(ILogger<TestingController> logger)
        {
            _logger = logger;
        }

        public IActionResult  Testing()
        {
            return View();
        }
    }
    public class TestsController : Controller
    {
        private readonly ILogger<TestsController> _logger;

        public TestsController(ILogger<TestsController> logger)
        {
            _logger = logger;
        }

        public IActionResult  Tests()
        {
            return View();
        }
    }
    public class HomePageController : Controller
    {
        private readonly ILogger<HomePageController> _logger;

        public HomePageController(ILogger<HomePageController> logger)
        {
            _logger = logger;
        }

        public IActionResult  HomePage()
        {
            return View();
        }
    }
    public class TestDescriptionController : Controller
    {
        private readonly ILogger<TestDescriptionController> _logger;

        public TestDescriptionController(ILogger<TestDescriptionController> logger)
        {
            _logger = logger;
        }

        public IActionResult  TestDescription()
        {
            return View();
        }
    }
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
    public class RegistrationFormController : Controller
    {
        private readonly ILogger<RegistrationFormController> _logger;

        public RegistrationFormController(ILogger<RegistrationFormController> logger)
        {
            _logger = logger;
        }

        public IActionResult RegistrationForm()
        {
            return View();
        }
    }
    public class PersonalAccountController : Controller
    {
        private readonly ILogger<PersonalAccountController> _logger;

        public PersonalAccountController(ILogger<PersonalAccountController> logger)
        {
            _logger = logger;
        }

        public IActionResult PersonalAccount()
        {
            return View();
        }
    }
    public class ThanksController : Controller
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
    public class RegistrationsController : Controller
    {
        private readonly ILogger<RegistrationsController> _logger;

        public RegistrationsController(ILogger<RegistrationsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Registration()
        {
            return View();
        }
    }
    
}