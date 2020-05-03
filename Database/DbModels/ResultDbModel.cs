namespace TestYou.Database.DbModels
{
    public class ResultDbModel
    {
        public int Id { set; get; }
        public int UserId { set; get; }
        public int TestId { set; get; }
        public bool isLike { set; get; }
        public string Description { set; get; }
    }
}