using GtRacingNews.Common.Constants;
using GtRacingNews.Data.DataModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GtRacingNews.Data.DBContext
{
    public class SqlDBContext : IdentityDbContext
    {
        private readonly ConnectionString connectionString = new ConnectionString();
        public SqlDBContext()
        {

        }
        public SqlDBContext(DbContextOptions<SqlDBContext> options)
           : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer(connectionString.SqlConnectionString);
            //}
        }

        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Championship> Championships { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.SetNull;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
