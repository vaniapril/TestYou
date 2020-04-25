using System;
using System.Collections.Generic;

namespace TestYou.Services.Models.Test
{
    public class Test
    {
        public string Title { set; get; }
        public int Id { set; get; }

        public List<Question> Questions { set; get; }
        
        public SortedDictionary<int, string> Result { set; get; }
    }
}