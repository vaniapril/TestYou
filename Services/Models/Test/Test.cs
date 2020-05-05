namespace TestYou.Services.Models.Test
{
    public class Test
    {
        public string Title { set; get; }
        public int Id { set; get; }
        public int UserId { set; get; }
        public string Description { set; get; }
        public Question[] Questions { set; get; }
        public TestResult[] Results { set; get; }
        public Comment[] Comments { get; set; }
    }
}