using System.Linq;
using System.Collections.Generic;
using TestYou.Services.Models.Test;
using AppContext = TestYou.Database.AppContext;

namespace TestYou.Services
{
    public class TestService
    {
        private readonly AppContext _appContext;
        private int _testMaxId;
        private int _commentMaxId;
        private int _answerMaxId;
        private int _testResultMaxId;
        private int _questionMaxId;
        
        public TestService()
        {
            _appContext = new AppContext();
            _testMaxId = 1;
            _commentMaxId = 1;
            _answerMaxId = 1;
            _testResultMaxId = 1;
            _questionMaxId = 1;
            foreach (var model in _appContext.answers)
            {
                if (model.Id > _answerMaxId)
                {
                    _answerMaxId = model.Id;
                }
            }
            foreach (var model in _appContext.comments)
            {
                if (model.Id > _commentMaxId)
                {
                    _commentMaxId = model.Id;
                }
            }
            foreach (var model in _appContext.tests)
            {
                if (model.Id > _testMaxId)
                {
                    _testMaxId = model.Id;
                }
            }
            foreach (var model in _appContext.test_results)
            {
                if (model.Id > _testResultMaxId)
                {
                    _testResultMaxId = model.Id;
                }
            }
            foreach (var model in _appContext.questions)
            {
                if (model.Id > _questionMaxId)
                {
                    _questionMaxId = model.Id;
                }
            }
        }

        public void Insert(Test test)
        {
            test.Id = ++_testMaxId;
            if (test.Comments != null)
            {
                foreach (var comment in test.Comments)
                {
                    comment.TestId = test.Id;
                    comment.Id = ++_commentMaxId;
                    _appContext.CommentInsert(Comment.ToDbModel(comment));
                } 
            }
            if (test.Results != null)
            {
                foreach (var testResult in test.Results)
                {
                    testResult.TestId = test.Id;
                    testResult.Id = ++_testResultMaxId;
                    _appContext.TestResultInsert(TestResult.ToDbModel(testResult));
                }
            }
            if (test.Questions != null)
            {
                foreach (var question in test.Questions)
                {
                    question.TestId = test.Id;
                    question.Id = ++_questionMaxId;
                    if (question.Answers != null)
                    {
                        foreach (var answer in question.Answers)
                        {
                            answer.QuestionId = question.Id;
                            answer.Id = ++_answerMaxId;
                            _appContext.AnswerInsert(Answer.ToDbModel(answer));
                        }
                    }
                    _appContext.QuestionInsert(Question.ToDbModel(question));
                } 
            }
            _appContext.TestInsert(Test.ToDbModel(test));
        }
        public List<Test> GetAll()
        {
            var tests = _appContext.tests.Select(Test.FromDbModel).ToList();
            tests.ForEach(test => { test.Questions = GetQuestionsByTestId(test.Id);});
            tests.ForEach(test => { test.Comments = GetCommentsByTestId(test.Id);});
            tests.ForEach(test => { test.Results = GetTestResultsByTestId(test.Id);});
            return tests;
        }
        public List<Test> GetByUserId(int id)
        {
            var tests = _appContext.tests.Select(Test.FromDbModel).Where(result => result.UserId == id).ToList();
            tests.ForEach(test => { test.Questions = GetQuestionsByTestId(test.Id);});
            tests.ForEach(test => { test.Comments = GetCommentsByTestId(test.Id);});
            tests.ForEach(test => { test.Results = GetTestResultsByTestId(test.Id);});
            return tests;
        }

        private Question[] GetQuestionsByTestId(int id)
        {
            var questions = _appContext.questions.Select(Question.FromDbModel).Where(question => question.TestId == id).ToArray();
            foreach (var question in questions)
            {
                question.Answers = GetAnswersByQuestionId(question.Id);
            }
            return questions;
        }
        private Comment[] GetCommentsByTestId(int id)
        {
            return _appContext.comments.Select(Comment.FromDbModel).Where(comment => comment.TestId == id).ToArray();
        }
        private TestResult[] GetTestResultsByTestId(int id)
        {
            return _appContext.test_results.Select(TestResult.FromDbModel).Where(testResult => testResult.TestId == id).ToArray();
        }
        private Answer[] GetAnswersByQuestionId(int id)
        {
            return _appContext.answers.Select(Answer.FromDbModel).Where(answer => answer.QuestionId == id).ToArray();
        }
    }
}