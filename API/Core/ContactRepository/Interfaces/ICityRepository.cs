using Data.Models;
using Core.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.PersonRepository.Interfaces //ESTA ES UNA INTERFAZ QUE SERA IMPLEMENTADA EN EL REPOSITORIO DE CITY
{
    public interface ICityRepository
    {
        Task<List<City>> GetAllCities();
        Task AddCity(CityDto request);
        Task UpdateCity(int id, CityDto request);
        Task DeleteCity(int id);
        Task<City> GetCityById(int id);
    }
}
