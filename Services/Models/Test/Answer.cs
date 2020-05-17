using TestYou.Database.DbModels;

namespace TestYou.Services.Models.Test
{
    public class Answer
    {
        public int Id { set; get; }
        public int QuestionId { set; get; }
        public string Text { set; get; }
        public int Cost { set; get; }
        public static Answer FromDbModel(AnswerDbModel model)
        {
            return new Answer
            {
                Id = model.Id,
                QuestionId = model.Id,
                Text = model.Text,
                Cost = model.Cost         };
        }
        public static AnswerDbModel ToDbModel(Answer item)
        {
            return new AnswerDbModel
            {
                Id = item.Id,
                TestId = item.Id,
                Text = item.Text,
                Cost = item.Cost
            };
        }
        public override string ToString()
        {
            return "Answer {Id: " + Id + ", TestId: " + QuestionId + ", Text: " + Text + ", Cost: " + Cost + "}";
        }
    }
}