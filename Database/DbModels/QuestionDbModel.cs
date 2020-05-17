using System.ComponentModel.DataAnnotations;

namespace TestYou.Database.DbModels
{
    public class QuestionDbModel
    {
        [Key]
        public int Id { set; get; }
        public int TestId { set; get; }
        public string Text { set; get; }
        public string Answers { set; get; }
    }
}