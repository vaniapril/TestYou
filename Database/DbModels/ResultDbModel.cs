﻿using System.ComponentModel.DataAnnotations;

namespace TestYou.Database.DbModels
{
    public class ResultDbModel
    {
        [Key]
        public int Id { set; get; }
        public int UserId { set; get; }
        public int TestId { set; get; }
        public int ResultId { set; get; }
    }
}