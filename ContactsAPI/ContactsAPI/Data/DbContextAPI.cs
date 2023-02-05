using ContactsAPI.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using System;

namespace ContactsAPI.Data
{
    public class DbContextAPI : DbContext
    {
        public DbContextAPI(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contact>? Contacts { get; set; }
        public DbSet<City>? Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .HasOne<City>(c=> c.City)
                .WithOne()
                .HasForeignKey<Contact>(c => c.CityFK);
        }
    }

}

    



