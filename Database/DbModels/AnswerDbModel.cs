using System.ComponentModel.DataAnnotations;

namespace TestYou.Database.DbModels
{
    public class AnswerDbModel
    {
        [Key]
        public int Id { set; get; }
        public int TestId { set; get; }
        public string Text { set; get; }
        public int Cost { set; get; }
    }
}