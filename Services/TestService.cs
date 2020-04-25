using System.Linq;
using System.Collections.Generic;
using TestYou.Database;
using TestYou.Database.DbModels;
using TestYou.Services.Models.Test;

namespace TestYou.Services
{
    public class TestService
    {
        private readonly AppContext _appContext;

        public TestService()
        {
            _appContext = new AppContext();
        }

        public List<Test> GetTests()
        {
            return _appContext.Tests.Select(BuildTest).ToList();
        }

        private Test BuildTest(TestDbModel u)
        {
            return new Test
            {
                Id = u.Id,
                Title = u.Title,
                Questions = u.Questions,
                Result = u.Result
            };
        }
    }
}