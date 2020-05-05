namespace TestYou.Services.Models.Test
{
    public class Comment
    {
        public int Id { set; get; }
        public int TestId { set; get; }
        public int UserId { set; get; }
        public bool IsLike { set; get; }
        public string Text { set; get; }
    }
}