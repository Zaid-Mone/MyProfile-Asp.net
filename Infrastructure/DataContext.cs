using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> option) : base(option)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Owner>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<PortfolioItem>().Property(p => p.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Owner>().HasData(
                new Owner()
                {
                    Id = Guid.NewGuid(),
                    Avatar = "card.png",
                    FullName = "Zaid Osama",
                    Profil = "Software Engineering / Web Development",
                }
                );
        }

        public DbSet<Owner> Owner { get; set; }
        public DbSet<PortfolioItem> portfolioItems { get; set; }

    }
}
