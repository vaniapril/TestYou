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

        public void AddResult(Result result)
        {
            _appContext.Results.Add(Result.ToDbModel(result));
        } 
        
        public List<Result> GetResultByUserId(int id)
        {
            return _appContext.Results.Select(Result.FromDbModel).Where(result => result.UserId == id).ToList();
        }
        public List<Result> GetResultByTestId(int id)
        {
            return _appContext.Results.Select(Result.FromDbModel).Where(result => result.TestId == id).ToList();
        }
        public List<Result> GetResult(int id)
        {
            return _appContext.Results.Select(Result.FromDbModel).ToList();
        }
    }
}