using GtRacingNews.Data.DataModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GtRacingNews.Data.DBContext
{
    public class GTNewsDbContext : IdentityDbContext
    {
        public GTNewsDbContext()
        {

        }
        public GTNewsDbContext(DbContextOptions<GTNewsDbContext> options)
           : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=GTNews;Integrated Security=true;");
            }
        }

        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Championship> Championships { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Readlater> ReadLater { get; set; }
        public DbSet<NewsReadLater> NewsReadLaters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<NewsReadLater>()
        .HasKey(x => new { x.ReadLaterId, x.NewsId });

            modelBuilder.Seed();
        }
    }
}
