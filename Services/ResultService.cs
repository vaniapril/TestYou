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
        private int _resultMaxId;
        public ResultService()
        {
            _appContext = new AppContext();
            _resultMaxId = 1;
            foreach (var model in _appContext.results)
            {
                if (model.Id > _resultMaxId)
                {
                    _resultMaxId = model.Id;
                }
            }
        }

        public void Insert(Result result)
        {
            result.Id = ++_resultMaxId;
            _appContext.ResultInsert(Result.ToDbModel(result));
        } 
        
        public List<Result> GetResultByUserId(int id)
        {
            return _appContext.results.Select(Result.FromDbModel).Where(result => result.UserId == id).ToList();
        }
        public List<Result> GetResultByTestId(int id)
        {
            return _appContext.results.Select(Result.FromDbModel).Where(result => result.TestId == id).ToList();
        }
        public List<Result> GetResult(int id)
        {
            return _appContext.results.Select(Result.FromDbModel).ToList();
        }
    }
}