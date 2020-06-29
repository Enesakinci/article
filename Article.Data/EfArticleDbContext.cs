using Article.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Article.Data
{
    public class EfArticleDbContext : DbContext
    {
        public EfArticleDbContext(DbContextOptions<EfArticleDbContext> options) : base(options) { }

        public DbSet<Article.Data.Model.Article> Article { get; set; }
        public DbSet<Category> Category { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
  
        }

    }
}
