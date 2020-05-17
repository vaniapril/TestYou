using TestYou.Database.DbModels;

namespace TestYou.Services.Models.Test
{
    public class Comment
    {
        public int Id { set; get; }
        public int TestId { set; get; }
        public int UserId { set; get; }
        public bool IsLike { set; get; }
        public string Text { set; get; }
        public static Comment FromDbModel(CommentDbModel model)
        {
            return new Comment
            {
                Id = model.Id,
                UserId = model.UserId,
                TestId = model.TestId,
                Text = model.Text,
                IsLike = model.IsLike
            };
        }
        public static CommentDbModel ToDbModel(Comment item)
        {
            return new CommentDbModel
            {
                Id = item.Id,
                UserId = item.UserId,
                TestId = item.TestId,
                Text = item.Text,
                IsLike = item.IsLike
            };
        }
        public override string ToString()
        {
            return "{Id: " + Id + ", TestId: " + TestId + ", UserId: " + UserId + ", Text: " + Text + ", IsLike: " + IsLike + "}";
        }
    }
}