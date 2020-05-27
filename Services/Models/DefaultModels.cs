using System.Collections.Generic;

namespace TestYou.Services.Models
{
    public static class DefaultModels
    {
        private static TestService _testService;
        private static UserService _userService;
        static DefaultModels()
        {
            _testService = new TestService();
            _userService = new UserService();
        }
        
        public static void Create()
        {
            CreateUsers();
            CreateTests();
        }
        static void CreateUsers()
        {
            
        }
        static void CreateTests()
        {
            
        }
    }
}