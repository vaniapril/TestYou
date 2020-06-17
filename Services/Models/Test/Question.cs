using TestYou.Database.DbModels;

namespace TestYou.Services.Models.Test
{
    public class Question
    {
        public int Id { set; get; }
        public int TestId { set; get; }
        public string Text { set; get; }
        public Answer[] Answers { set; get; }
        public static Question FromDbModel(QuestionDbModel model)
        {
            return new Question
            {
                Id = model.Id,
                TestId = model.TestId,
                Text = model.Text,
            };
        }
        public static QuestionDbModel ToDbModel(Question item)
        {
            return new QuestionDbModel
            {
                Id = item.Id,
                TestId = item.TestId,
                Text = item.Text,
            };
        }
        public override string ToString()
        {
            string answ = "";
            if (Answers != null && Answers.Length != 0)
            {
                foreach (var answer in Answers)
                {
                    answ += answer.ToString() + ", ";
                }
                answ = answ.Substring(0, answ.Length - 2);
            }
            return "{Id: " + Id + ", TestId: " + TestId + ", Text: " + Text + ", Answers: [" + answ + "]}";
        }
    }
}