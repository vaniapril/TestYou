using System.ComponentModel.DataAnnotations;

namespace TestYou.Database.DbModels
{
    public class UserDbModel
    {
        [Key]
        public int Id { set; get; }
        public string Password { set; get;}
        public string Login { set; get; }
    }
}