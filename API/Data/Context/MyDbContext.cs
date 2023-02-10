using Data.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using System;

namespace Data.Context
{
    public class MyDbContext : DbContext //ESTA CLASE VA SER EL CONSTRUCTOR DEL CONTEXTO DE NUESTRA BASE DE DATOS
    {
        public MyDbContext(DbContextOptions options) : base(options)//CONFIGURAMOS NUESTRA BASE DE DATOS
        {
        }

        public DbSet<Contact> Contacts { get; set; }//DECLARAMOS NUESTROS MODELOS PARA CONVERTIRLOS EN TABLAS 
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                        .HasOne<City>(c => c.City)
                        .WithMany()
                        .HasForeignKey(c => c.CityFK)
                        .OnDelete(DeleteBehavior.Restrict);//ESTABLECEMOS UNA RELACION DE UNO A MUCHOS MEDIANTE LA FK CityFK

            modelBuilder.Entity<Contact>().HasIndex(c => c.CityFK).IsUnique(false).HasName("IX_Contacts_CityFK");//ELIMINAMOS EL INDICE UNICO EN CityFK

        }



    }

}

    



