using System.ComponentModel.DataAnnotations;

namespace TestYou.Database.DbModels
{
    public class TestResultDbModel
    {
        [Key]
        public int Id { set; get; }
        public int TestId { set; get; }
        public string Text { set; get; }
        public int Min { set; get; }
        public int Max { set; get; }
    }
}