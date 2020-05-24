using System.Linq;
using Microsoft.EntityFrameworkCore;
using TestYou.Database.DbModels;
using TestYou.Services.Models.Test;

namespace TestYou.Database
{
    public class AppContext : DbContext
    {
        public DbSet<UserDbModel> users { get; set; }
        public DbSet<TestDbModel> tests { get; set; }
        public DbSet<QuestionDbModel> questions { get; set; }
        public DbSet<ResultDbModel> results { get; set; }
        public DbSet<CommentDbModel> comments { get; set; }
        public DbSet<TestResultDbModel> test_results { set; get; }
        public DbSet<AnswerDbModel> answers { set; get; }
        
        public void UserInsert(UserDbModel item)
        {
           var model = users.FirstOrDefault(i => i.Id == item.Id);
            if (model != null)
            {
                Entry(model).State = EntityState.Detached;
                Entry(item).State = EntityState.Modified;
            }
            else
            {
                users.Add(item);
            }
            SaveChanges();
        }
        public void TestInsert(TestDbModel item)
        {
            var model = tests.FirstOrDefault(i => i.Id == item.Id);
            if (model != null)
            {
                Entry(model).State = EntityState.Detached;
                Entry(item).State = EntityState.Modified;
            }
            else
            {
                tests.Add(item);
            }
            SaveChanges();
        }
        public void QuestionInsert(QuestionDbModel item)
        {
            var model = questions.FirstOrDefault(i => i.Id == item.Id);
            if (model != null)
            {
                Entry(model).State = EntityState.Detached;
                Entry(item).State = EntityState.Modified;
            }
            else
            {
                questions.Add(item);
            }
            SaveChanges();
        }
        public void ResultInsert(ResultDbModel item)
        {
            var model = results.FirstOrDefault(i => i.Id == item.Id);
            if (model != null)
            {
                Entry(model).State = EntityState.Detached;
                Entry(item).State = EntityState.Modified;
            }
            else
            {
                results.Add(item);
            }
            SaveChanges();
        }
        public void AnswerInsert(AnswerDbModel item)
        {
            var model = answers.FirstOrDefault(i => i.Id == item.Id);
            if (model != null)
            {
                Entry(model).State = EntityState.Detached;
                Entry(item).State = EntityState.Modified;
            }
            else
            {
                answers.Add(item);
            }
            SaveChanges();
        }
        public void TestResultInsert(TestResultDbModel item)
        {
            var model = test_results.FirstOrDefault(i => i.Id == item.Id);
            if (model != null)
            {
                Entry(model).State = EntityState.Detached;
                Entry(item).State = EntityState.Modified;
            }
            else
            {
                test_results.Add(item);
            }
            SaveChanges();
        }
        public void CommentInsert(CommentDbModel item)
        {
            var model = comments.FirstOrDefault(i => i.Id == item.Id);
            if (model != null)
            {
                Entry(model).State = EntityState.Detached;
                Entry(item).State = EntityState.Modified;
            }
            else
            {
                comments.Add(item);
            }
            SaveChanges();
        }

        public void UserDelete(UserDbModel item)
        {
            var model = users.FirstOrDefault(i => i.Id == item.Id);
            if (model != null)
            {
                Entry(model).State = EntityState.Detached;
                Entry(item).State = EntityState.Deleted;
            }
        }
        public void TestDelete(TestDbModel item)
        {
            var model = tests.FirstOrDefault(i => i.Id == item.Id);
            if (model != null)
            {
                Entry(model).State = EntityState.Detached;
                Entry(item).State = EntityState.Deleted;
            }
        }
        public void QuestionDelete(QuestionDbModel item)
        {
            var model = questions.FirstOrDefault(i => i.Id == item.Id);
            if (model != null)
            {
                Entry(model).State = EntityState.Detached;
                Entry(item).State = EntityState.Deleted;
            }
        }
        public void AnswerDelete(AnswerDbModel item)
        {
            var model = answers.FirstOrDefault(i => i.Id == item.Id);
            if (model != null)
            {
                Entry(model).State = EntityState.Detached;
                Entry(item).State = EntityState.Deleted;
            }
        }
        public void TestResultDelete(TestResultDbModel item)
        {
            var model = test_results.FirstOrDefault(i => i.Id == item.Id);
            if (model != null)
            {
                Entry(model).State = EntityState.Detached;
                Entry(item).State = EntityState.Deleted;
            }
        }
        public void CommentDelete(CommentDbModel item)
        {
            var model = comments.FirstOrDefault(i => i.Id == item.Id);
            if (model != null)
            {
                Entry(model).State = EntityState.Detached;
                Entry(item).State = EntityState.Deleted;
            }
        }
        
        public AppContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=TestYou;Username=postgres;Password=1234");
        }
    }
}