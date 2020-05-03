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
            var tests = _appContext.Tests.Select(BuildTest).ToList();
            tests.ForEach(test => { test.Questions = GetQuestionsByTestId(test.Id);});
            return tests;
        }

        private Test BuildTest(TestDbModel t)
        {
            return new Test
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                UserId = t.UserId,
                Result = t.Result.Split('/')
            };
        }
        
        public Question[] GetQuestionsByTestId(int id)
        {
            return _appContext.Qestions.Select(BuildQuestion).Where(question => question.TestId == id).ToArray();
        }

        private Question BuildQuestion(QuestionDbModel q)
        {
            return new Question
            {
                Id = q.Id,
                TestId = q.TestId,
                Text = q.Text,
                Answers = q.Answers.Split('/')
            };
        }
    }
}