namespace TestYou.Database.DbModels
{
    public class CommentDbModel
    {
        public int Id { set; get; }
        public int TestId { set; get; }
        public int UserId { set; get; }
        public bool IsLike { set; get; }
        public string Text { set; get; }
    }
}