﻿using Data.Model;
using Microsoft.EntityFrameworkCore;


namespace Data.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
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

    


