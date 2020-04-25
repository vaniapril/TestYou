using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TestYou.Services.Models.Test;

namespace TestYou.Database.DbModels
{
    public class TestDbModel
    {
        public string Title { set; get; }
        public int Id { set; get; }
        
        [Column(TypeName = "jsonb")]
        public List<Question> Questions { set; get; }
        
        [Column(TypeName = "jsonb")]
        public SortedDictionary<int, string> Result { set; get; }
    }
}