using Microsoft.EntityFrameworkCore;
using TestYou.Database.DbModels;

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