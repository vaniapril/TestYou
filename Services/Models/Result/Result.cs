namespace TestYou.Services.Models.Result
{
    public class Result
    {
        public int Id { set; get; }
        public int UserId { set; get; }
        public int TestId { set; get; }
        public string Description { set; get; }
        public bool isLike { set; get; }
    }
}