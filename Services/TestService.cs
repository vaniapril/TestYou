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

        public void AddTest(Test test)
        {
            if (test.Comments != null)
            {
                foreach (var comment in test.Comments)
                {
                    _appContext.Comments.Add(Comment.ToDbModel(comment));
                } 
            }
            if (test.Results != null)
            {
                foreach (var testResult in test.Results)
                {
                    _appContext.TestResult.Add(TestResult.ToDbModel(testResult));
                }
            }
            if (test.Questions != null)
            {
                foreach (var question in test.Questions)
                {
                    _appContext.Qestions.Add(Question.ToDbModel(question));
                } 
            }
            _appContext.Tests.Add(Test.ToDbModel(test));
        }
        
        public List<Test> GetTests()
        {
            var tests = _appContext.Tests.Select(Test.FromDbModel).ToList();
            tests.ForEach(test => { test.Questions = GetQuestionsByTestId(test.Id);});
            tests.ForEach(test => { test.Comments = GetCommentsByTestId(test.Id);});
            tests.ForEach(test => { test.Results = GetTestResultsByTestId(test.Id);});
            return tests;
        }
        public List<Test> GetTestsByUserId(int id)
        {
            var tests = _appContext.Tests.Select(Test.FromDbModel).Where(result => result.UserId == id).ToList();
            tests.ForEach(test => { test.Questions = GetQuestionsByTestId(test.Id);});
            tests.ForEach(test => { test.Comments = GetCommentsByTestId(test.Id);});
            tests.ForEach(test => { test.Results = GetTestResultsByTestId(test.Id);});
            return tests;
        }
        
        private Question[] GetQuestionsByTestId(int id)
        {
            return _appContext.Qestions.Select(Question.FromDbModel).Where(question => question.TestId == id).ToArray();
        }
        private Comment[] GetCommentsByTestId(int id)
        {
            return _appContext.Comments.Select(Comment.FromDbModel).Where(comment => comment.TestId == id).ToArray();
        }
        private TestResult[] GetTestResultsByTestId(int id)
        {
            return _appContext.TestResult.Select(TestResult.FromDbModel).Where(testResult => testResult.TestId == id).ToArray();
        }
    }
}