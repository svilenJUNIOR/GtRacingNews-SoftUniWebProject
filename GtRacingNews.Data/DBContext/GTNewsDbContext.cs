﻿using GtRacingNews.Data.DataModels;
using Microsoft.EntityFrameworkCore;

namespace GtRacingNews.Data.DBContext
{
    public class GTNewsDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=GTNews;Integrated Security=true;");
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Championship> Championships { get; set; }
        public DbSet<News> News { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}