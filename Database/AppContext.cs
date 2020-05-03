using Microsoft.EntityFrameworkCore;
using TestYou.Database.DbModels;

namespace TestYou.Database
{
    public class AppContext : DbContext
    {
        public DbSet<UserDbModel> Users { get; set; }
        public DbSet<TestDbModel> Tests { get; set; }
        public DbSet<QuestionDbModel> Qestions { get; set; }
        public DbSet<ResultDbModel> Results { get; set; }
        
        public AppContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=TestYou;Username=postgres;Password=12341234");
        }
    }
}