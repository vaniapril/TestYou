using TestYou.Database.DbModels;
using TestYou.Services.Models.Test;

namespace TestYou.Services.Models.Result
{
    public class Result
    {
        public int Id { set; get; }
        public int UserId { set; get; }
        public int TestId { set; get; }
        public int ResultId { set; get; }
        public static Result FromDbModel(ResultDbModel model)
        {
            return new Result
            {
                Id = model.Id,
                ResultId = model.ResultId,
                TestId = model.TestId,
                UserId = model.UserId
            };
        }
        public static ResultDbModel ToDbModel(Result item)
        {
            return new ResultDbModel
            {
                Id = item.Id,
                ResultId = item.ResultId,
                TestId = item.TestId,
                UserId = item.UserId
            };
        }
        public override string ToString()
        {
            return "{\nId: " + Id + ", \nUserId: " + UserId + ", \nTestId: " + TestId + ", \nResultId: " + ResultId + "\n}";
        }
    }
}