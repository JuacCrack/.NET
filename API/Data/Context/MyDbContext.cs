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

        protected override void OnModelCreating(ModelBuilder modelBuilder)//DECLARAMOS LA RELACION DE NUESTRAS TABLAS
        {
            modelBuilder.Entity<Contact>()//UN CONTACTO
                .HasOne<City>(c=> c.City)//VA A TENER UN CAMPO DE CIUDAD
                .WithOne()
                .HasForeignKey<Contact>(c => c.CityFK);//ESA CLAVE FORANEA VA A SER EL CAMPO CITYFK
        }
    }

}

    



