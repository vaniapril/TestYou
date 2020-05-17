using System.ComponentModel.DataAnnotations;

namespace TestYou.Database.DbModels
{
    public class TestDbModel
    {
        [Key]
        public int Id { set; get; }
        public string Title { set; get; }
        public int UserId { set; get; }
        public string Description { set; get; }
    }
}