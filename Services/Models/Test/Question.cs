using System;
using System.Linq;
using TestYou.Database.DbModels;

namespace TestYou.Services.Models.Test
{
    public class Question
    {
        public int Id { set; get; }
        public int TestId { set; get; }
        public string Text { set; get; }
        public string[] Answers { set; get; }
        public static Question FromDbModel(QuestionDbModel model)
        {
            return new Question
            {
                Id = model.Id,
                TestId = model.Id,
                Text = model.Text,
                Answers = model.Answers.Split('/')
            };
        }
        public static QuestionDbModel ToDbModel(Question item)
        {
            string answers = "";
            foreach (var itemAnswer in item.Answers)
            {
                answers += itemAnswer + "/";
            }
            return new QuestionDbModel
            {
                Id = item.Id,
                TestId = item.Id,
                Text = item.Text,
                Answers = answers.Substring(0,answers.Length - 1)
            };
        }
        public override string ToString()
        {
            return "Question {Id: " + Id + ", TestId: " + TestId + ", Text: " + Text + ", Answers: " + Answers + "}";
        }
    }
}