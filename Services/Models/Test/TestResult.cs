using TestYou.Database.DbModels;

namespace TestYou.Services.Models.Test
{
    public class TestResult
    {
        public int Id { set; get; }
        public int TestId { set; get; }
        public string Text { set; get; }
        public int Min { set; get; }
        public int Max { set; get; }
        public static TestResult FromDbModel(TestResultDbModel model)
        {
            return new TestResult
            {
                Id = model.Id,
                TestId = model.TestId,
                Max = model.Max,
                Min = model.Min,
                Text = model.Text
            };
        }
        public static TestResultDbModel ToDbModel(TestResult item)
        {
            return new TestResultDbModel
            {
                Id = item.Id,
                TestId = item.TestId,
                Max = item.Max,
                Min = item.Min,
                Text = item.Text
            };
        }
        public override string ToString()
        {
            return "TestResult {Id: " + Id + ", TestId: " + TestId + ", Text: " + Text + ", Min: " + Min + ", Max: " + Max + "}";
        }
    }
}