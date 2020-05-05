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
            tests.ForEach(test => { test.Comments = GetCommentsByTestId(test.Id);});
            tests.ForEach(test => { test.Results = GetTestResultsByTestId(test.Id);});
            return tests;
        }
        public List<Test> GetTestsByUserId(int id)
        {
            var tests = _appContext.Tests.Select(BuildTest).Where(result => result.UserId == id).ToList();
            tests.ForEach(test => { test.Questions = GetQuestionsByTestId(test.Id);});
            tests.ForEach(test => { test.Comments = GetCommentsByTestId(test.Id);});
            tests.ForEach(test => { test.Results = GetTestResultsByTestId(test.Id);});
            return tests;
        }
        
        private Question[] GetQuestionsByTestId(int id)
        {
            return _appContext.Qestions.Select(BuildQuestion).Where(question => question.TestId == id).ToArray();
        }
        private Comment[] GetCommentsByTestId(int id)
        {
            return _appContext.Comments.Select(BuildComment).Where(comment => comment.TestId == id).ToArray();
        }
        private TestResult[] GetTestResultsByTestId(int id)
        {
            return _appContext.TestResult.Select(BuildTestResult).Where(testResult => testResult.TestId == id).ToArray();
        }
        private Test BuildTest(TestDbModel t)
        {
            return new Test
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                UserId = t.UserId,
            };
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
        private Comment BuildComment(CommentDbModel c)
        {
            return new Comment
            {
                Id = c.Id,
                TestId = c.TestId,
                Text = c.Text,
                IsLike = c.IsLike,
                UserId = c.UserId
            };
        }
        private TestResult BuildTestResult(TestResultDbModel c)
        {
            return new TestResult
            {
                Id = c.Id,
                TestId = c.TestId,
                Text = c.Text,
                Min = c.Min,
                Max = c.Max
            };
        }
    }
}