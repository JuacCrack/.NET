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
    [Route("api/people")]
    [ApiController]
    public class ContactController : ControllerBase //CONTROLADOR PRINCIPAL
    {
        //CONSTRUCTOR PRIVADO DE IContactRepository 

        private readonly IContactRepository _contactRepository;

        //CONSTRUCTOR ContactController utiliza IContactRepository -> varable de solo lectura -> _contactRepository.
        //La variable _contactRepository se utiliza para interactuar con la Base de Datos
        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        //TRAER TODOS LOS CONTACTOS
        [HttpGet]
        public async Task<ActionResult<List<Contact>>> Get()
        {
            var contacts = await _contactRepository.GetAll();
            return Ok(contacts);
        }
        //TRAER CONTACTO POR ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> Get(Guid id)
        {
            var contact = await _contactRepository.Get(id);
            if (contact == null) 
            {
                return NotFound();//SI LA ID ES NULL O NO SE ENCUENTRA DEVUELVE UN 404
            }
            return Ok(contact);// CASO CONTRARIO DEVUELVE EL CONTACTO POR ID
        }
        //TRAER CONTACTO ALEATORIO
        [HttpGet("shuffle")]
        public async Task<ActionResult<Contact>> GetShuffle()
        {
            var contact = await _contactRepository.GetShuffle();
            if (contact == null) 
            {
                return NotFound();//SI POR ALGUN MOTIVO NO PUEDE TRAER UN CONTACTO ALEATORIO DEVUELVE UN 404
            }
            return Ok(contact);//CASO CONTRARIO DEVUELVE UN CONTACTO ALEATORIO
        }
        //CARGAR CONTACTO
        [HttpPost]
        public async Task<ActionResult<Contact>> AddContact(Request request)
        {
           await _contactRepository.AddContact(request);//UTILIZA EL MODELO REQUEST PARA CARGARLO EN EL MODELO CONTACTO Y SUBIRLO A LA BASE DE DATOS
            return Ok();//AL CARGAR EL CONTACTO DEVUELVE UN 200
        }
        //ACTUALIZAR CONTACTO
        [HttpPut("{id}")]
        public async Task<ActionResult<Contact>> UpdateContact(Guid id, Request request)
        {
            var contact = await _contactRepository.Get(id); //SOLICITA LA BUSQUEDA DE UNA ID 
            if (contact == null) 
            {
                return NotFound(); // SI LA ID ES NULA DEVUELVE UN 404
            }
            await _contactRepository.UpdateContact(id, request); //CASO CONTRARIO UTILIZA LA ID SOLICITADA Y EL MODELO REQUEST PARA UN UPDATE AL MODELO CONTACTO Y SUBIRLO A LA BASE DE DATOS
            return Ok(contact);// SI ESTO SE REALIZA DEVUELVE UN 200
        }
        //BORRAR CONTACTO
        [HttpDelete("{id}")]
        public async Task<ActionResult<Contact>> Delete(Guid id)
        {
            var contact = await _contactRepository.Get(id); //SOLICITA LA BUSQUEDA DE UNA ID 
            if (contact == null)
            {
                return NotFound();// SI LA ID ES NULA DEVUELVE UN 404
            }
            await _contactRepository.Delete(id);//SI LA ID ES VALIDA BORRA LA ID SOLICITADA
            return Ok(contact);// SI ESTO SE REALIZA DEVUELVE UN 200
        }
        //FILTRAR POR CIUDAD
        [HttpGet("GetContactByCity/{name}")]
        public async Task<ActionResult> GetCity(string name)
        {
            var contacts = await _contactRepository.GetCity(name);//REALIZA LA BUSQUEDA DE UN CITY NAME SOLICITADO EN LA RUTA
            if (contacts == null)
            {
                return NotFound();//SI NO SE ENCUENTRA LA CITY NAME DEVUELVE UN 4O4
            }

            return Ok(contacts);//SI ENCUENTRA LA CITY NAME DEVUELVE UN 200
        }

        //FILTRAR POR CIUDAD
        [HttpGet("GetContactByEmail/{email}")]
        public async Task<ActionResult<Contact>> GetEmail(string email)
        {
            var contact = await _contactRepository.GetEmail(email);//REALIZA LA BUSQUEDA DE UN EMAIL SOLICITADO EN LA RUTA

            if (contact == null)
            {
                return NotFound();//SI NO SE ENCUENTRA EL EMAIL DEVUELVE UN 4O4
            }

            return Ok(contact);//SI ENCUENTRA EL EMAIL DEVUELVE UN 200
        }

    }
}
