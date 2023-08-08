using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Infrastructure
{
    public class DataContext : DbContext

    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Owner>().Property(x=>x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<PortfolioItem>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Owner>().HasData(
                new Owner() 
                { Id = Guid.NewGuid(), 
                  Avatar ="avatare.jpg",
                  FullName ="abdallahtrabelsi",
                  Profil="micro mvp /.net consulting"
                });


        }
        public DbSet <Owner> Owner { get; set; }
        public DbSet<PortfolioItem> portfolioItems { get; set; }
    }
}
