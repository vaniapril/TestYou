using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestYou.Database.DbModels
{
    public class UserDbModel
    {
        public string Password { set; get;}
        public string Login { set; get; }
        public int Id { set; get; }
        
        [Column(TypeName = "jsonb")]
        public SortedDictionary<int, int> Results { set; get; }
    }
}