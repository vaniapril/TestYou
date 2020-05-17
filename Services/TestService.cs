﻿using System.Linq;
using System.Collections.Generic;
using TestYou.Database;
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
                    _appContext.comments.Add(Comment.ToDbModel(comment));
                } 
            }
            if (test.Results != null)
            {
                foreach (var testResult in test.Results)
                {
                    _appContext.testResults.Add(TestResult.ToDbModel(testResult));
                }
            }
            if (test.Questions != null)
            {
                foreach (var question in test.Questions)
                {
                    if (question.Answers != null)
                    {
                        foreach (var answer in question.Answers)
                        {
                            _appContext.answers.Add(Answer.ToDbModel(answer));
                        }
                    }
                    _appContext.questions.Add(Question.ToDbModel(question));
                } 
            }
            _appContext.tests.Add(Test.ToDbModel(test));
            _appContext.SaveChanges();
        }
        
        public List<Test> GetTests()
        {
            var tests = _appContext.tests.Select(Test.FromDbModel).ToList();
            tests.ForEach(test => { test.Questions = GetQuestionsByTestId(test.Id);});
            tests.ForEach(test => { test.Comments = GetCommentsByTestId(test.Id);});
            tests.ForEach(test => { test.Results = GetTestResultsByTestId(test.Id);});
            return tests;
        }
        public List<Test> GetTestsByUserId(int id)
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
            return _appContext.testResults.Select(TestResult.FromDbModel).Where(testResult => testResult.TestId == id).ToArray();
        }
        private Answer[] GetAnswersByQuestionId(int id)
        {
            return _appContext.answers.Select(Answer.FromDbModel).Where(answer => answer.QuestionId == id).ToArray();
        }
    }
}