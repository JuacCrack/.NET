using Core.DTO;
using Core.PersonRepository.Interfaces;
using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.PersonRepository.Implementations
{
    public class CityRepository : ICityRepository //ESTA IMPLEMENTACION UTILIZA LA INTERFAZ DE CONTACT REPOSITORIO
    {
        private readonly MyDbContext _context; //CONSTRUCTOR PRIVADO DEL DB CONTEXT QUE UTILIZA EL PARAMETRO _context
        public CityRepository(MyDbContext context)//CONSTRUCTOR DE CONTACT REPOSITORIO QUE IMPLEMENTA EL DBCONTEXT EN UN PARAMETRO _context9
        {
            _context = context; 
        }
        //AGREGAR CIUDAD
        public async Task AddCity(CityDto request)
        {
            var city = new City //NUEVO MODELO DE CITY
            {
                name = request.name //UTILIZAMOS EL MODELO REQUEST PARA CARGAR AL MODELO CITY
            };

            await _context.Cities.AddAsync(city);//AGREGAMOS LOS CAMBIOS A CITY
           await _context.SaveChangesAsync();//Y GUARDAMOS LOS CAMBIOS
        }
        //TRAER CIUDAD POR ID
        public async Task<City> GetCityById(int id)
        {
            return await _context.Cities.FindAsync(id);//UTILIZAMOS LA ID DE LA RUTA PARA DEVOLVER UNA CIUDAD SEGUN LA ID
        }
        //BORRAR CIUDAD
        public async Task DeleteCity(int id)
        {
            var city = await _context.Cities.FindAsync(id);//BUSCAMOS LA ID DE LA RUTA
            _context.Cities.Remove(city);//UTILIZAMOS EL DBCONTEXT PARA BORRAR LA CIUDAD DE LA DB
           await _context.SaveChangesAsync();//GUARDAMOS LOS CAMBIOS
        }
        //TRAER TODOS LAS CIUDADES
        public async Task<List<City>> GetAllCities()
        {
            return await _context.Cities.ToListAsync();//DEVOLVEMOS TODA LA LISTA CITY FORMA DE LISTA
        }
        //ACTUALIZAR CIUDAD
        public async Task UpdateCity(int id, CityDto request)
        {
            var city = await _context.Cities.FindAsync(id); //BUSCAMOS EN LA TABLA LA ID SOLICITADA
            if (city == null)
            {
                throw new Exception("No se encontro la Ciudad");//SI LA ID NO ESTA SE DEVUELVE UN EXCEPTION
            }
            city.name = request.name;//CASO CONTRARIO UTILIZAMOS EL REQUEST PARA CARGAR UNA NUEVA CIUDAD AL MODELO CITY
            _context.Cities.Update(city);//HACEMOS EL UPDATE
            await _context.SaveChangesAsync();//GUARDAMOS LOS CAMBIOS
        }

    }
}

