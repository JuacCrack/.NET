using Core.DTO;
using Core.PersonRepository.Interfaces;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/city")]
    [ApiController]
    public class CityController : ControllerBase //CONTROLADOR PRINCIPAL
    {
        //CONSTRUCTOR PRIVADO DE ICityRepository 

        private readonly ICityRepository _cityRepository;

        //CONSTRUCTOR CityController utiliza ICityRepository -> varable de solo lectura -> _cityRepository.
        //La variable _cityRepository se utiliza para interactuar con la Base de Datos
        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        //TRAER TODOS LAS CIUDADES
        [HttpGet("GetAllCities")]
        public async Task<ActionResult<List<City>>> Get()
        {
            var city = await _cityRepository.GetAllCities();
            return Ok(city);
        }
        //TRAER CIUDAD POR ID
        [HttpGet("GetCityById/{id}")]
        public async Task<ActionResult<City>> GetCityById(int id)
        {
            var city = await _cityRepository.GetCityById(id);
            if (city == null) 
            {
                return NotFound();//SI LA ID ES NULL O NO SE ENCUENTRA DEVUELVE UN 404
            }
            return Ok(city);// CASO CONTRARIO DEVUELVE LA CIUDAD POR ID
        }
        //CARGAR CIUDAD
        [HttpPost("PostCity")]
        public async Task<ActionResult<City>> AddCity(CityDto request)
        {
           await _cityRepository.AddCity(request);//UTILIZA EL MODELO REQUEST PARA CARGARLO EN EL MODELO CITY Y SUBIRLO A LA BASE DE DATOS
            return Ok();//AL CARGAR LA CIUDAD DEVUELVE UN 200
        }
        //ACTUALIZAR CIUDAD
        [HttpPut("UpdateCityById/{id}")]
        public async Task<ActionResult<City>> UpdateCity(int id, CityDto request)
        {
            var city = await _cityRepository.GetCityById(id); //SOLICITA LA BUSQUEDA DE UNA ID 
            if (city == null) 
            {
                return NotFound(); // SI LA ID ES NULA DEVUELVE UN 404
            }
            await _cityRepository.UpdateCity(id, request); //CASO CONTRARIO UTILIZA LA ID SOLICITADA Y EL MODELO REQUEST PARA UN UPDATE AL MODELO CITY Y SUBIRLO A LA BASE DE DATOS
            return Ok(city);// SI ESTO SE REALIZA DEVUELVE UN 200
        }
        //BORRAR CIUDAD
        [HttpDelete("DeleteById/{id}")]
        public async Task<ActionResult<City>> DeleteCity(int id)
        {
            var city = await _cityRepository.GetCityById(id); //SOLICITA LA BUSQUEDA DE UNA ID 
            if (city == null)
            {
                return NotFound();// SI LA ID ES NULA DEVUELVE UN 404
            }
            await _cityRepository.DeleteCity(id);//SI LA ID ES VALIDA BORRA LA ID SOLICITADA
            return Ok(city);// SI ESTO SE REALIZA DEVUELVE UN 200
        }
    }
}
