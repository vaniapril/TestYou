using TestYou.Database.DbModels;

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
        public static Test FromDbModel(TestDbModel model)
        {
            return new Test
            {
                Id = model.Id,
                Description = model.Description,
                UserId = model.UserId,
                Title = model.Title
            };
        }
        public static TestDbModel ToDbModel(Test item)
        {
            return new TestDbModel
            {
                Id = item.Id,
                Description = item.Description,
                UserId = item.UserId,
                Title = item.Title
            };
        }
        public override string ToString()
        {
            string q = "";
            string r = "";
            string c = "";
            if (Comments != null && Comments.Length != 0)
            {
                foreach (var comment in Comments)
                {
                    c += comment.ToString() + ",\n";
                }

                c = c.Substring(0, c.Length - 2);
            }
            if (Results != null && Results.Length != 0)
            {
                foreach (var testResult in Results)
                {
                    r += testResult.ToString() + ",\n";
                }

                r = r.Substring(0, r.Length - 2);
            }
            if (Questions != null && Questions.Length != 0)
            {
                foreach (var question in Questions)
                {
                    q += question.ToString() + ",\n";
                }
                q = q.Substring(0, q.Length - 2);
            }
            return "{\n    Id: " + Id + ", \n    Title: " + Title +
                   ", \n    UserId: " + UserId + ", \n    Description: " + Description + 
                   ", \n    Question: [" + q +
                   "], \n    TestResult: [" + r +
                   "], \n    Comment: [" + c + "]\n}";
        }
    }
}