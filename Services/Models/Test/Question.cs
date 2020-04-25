using System.Collections.Generic;

namespace TestYou.Services.Models.Test
{
    public class Question
    {
        public string Text { set; get; }
        private SortedDictionary<string, int> Answers { set; get; }
    }
}