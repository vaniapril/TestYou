﻿namespace TestYou.Services.Models.Test
{
    public class Question
    {
        public int Id { set; get; }
        public int TestId { set; get; }
        public string Text { set; get; }
        public string[] Answers { set; get; }
    }
}