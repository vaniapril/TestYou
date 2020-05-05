using System.Collections.Generic;
using System.Linq;
using TestYou.Database;
using TestYou.Database.DbModels;
using TestYou.Services.Models.Result;

namespace TestYou.Services
{
    public class ResultService
    {
        private readonly AppContext _appContext;
        public ResultService()
        {
            _appContext = new AppContext();
        }
        
        public List<Result> GetResultByUserId(int id)
        {
            return _appContext.Results.Select(BuildResult).Where(result => result.UserId == id).ToList();
        }
        public List<Result> GetResultByTestId(int id)
        {
            return _appContext.Results.Select(BuildResult).Where(result => result.TestId == id).ToList();
        }
        public List<Result> GetResult(int id)
        {
            return _appContext.Results.Select(BuildResult).ToList();
        }
        private Result BuildResult(ResultDbModel r)
        {
            return new Result
            {
                Id = r.Id,
                UserId = r.UserId,
                TestId = r.TestId,
                Description = r.Description,
            };
        }
    }
}