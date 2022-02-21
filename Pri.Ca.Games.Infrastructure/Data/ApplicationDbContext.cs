using Microsoft.EntityFrameworkCore;
using Pri.Ca.Games.Core.Entities;
using Pri.Ca.Games.Infrastructure.Data.Seeding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Ca.Games.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //set some database constraints
            modelBuilder.Entity<Game>().Property(e => e.Name)
                .HasMaxLength(250)
                .IsRequired();
            modelBuilder.Entity<Genre>().Property(e => e.Name)
                .HasMaxLength(250)
                .IsRequired();
        
            

            Seeder.Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
