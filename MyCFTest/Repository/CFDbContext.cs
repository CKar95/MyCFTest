using Microsoft.EntityFrameworkCore;
using MyCFTest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCFTest.Repository
{
    public class CFDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Backer> Backers { get; set; }
        public DbSet<ProjectCreator> ProjectCreators { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<PackageFund> PackageFunds { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<ProjectStatus> ProjectStatuses { get; set; }


        public readonly static string ConnectionString =
            "Server =localhost; " +
            "Database = MyCFTest; " +
            "User Id = sa; " +
            "Password = admin!@#123;";


        //public CFDbContext(DbContextOptions<CFDbContext> options)
        //        : base(options)
        //{ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasDiscriminator<string>("Role");
        }


        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
