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
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        //TRAER TODOS LOS CONTACTOS
        [HttpGet]
        public ActionResult<List<Contact>> Get()
        {
            var contacts = _contactRepository.GetAll();
            if (contacts.Count != 0) return Ok(_contactRepository.GetAll());
            return StatusCode(204, "La lista de contactos esta vacia");
        }
        //TRAER CONTACTO POR ID
        [HttpGet("{id}")]
        public ActionResult<Contact> Get(Guid id)
        {
            var contact = _contactRepository.Get(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }
        //TRAER CONTACTO ALEATORIO
        [HttpGet("shuffle")]
        public ActionResult<Contact> GetShuffle()
        {
            var contact = _contactRepository.GetShuffle();
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }
        //CARGAR CONTACTO
        [HttpPost]
        public ActionResult<Contact> AddContact(AddContactRequest request)
        {
            _contactRepository.AddContact(request);
            return Ok();
        }
        //ACTUALIZAR CONTACTO
        [HttpPut("{id}")]
        public ActionResult<Contact> UpdateContact(Guid id, UpdateContactRequest request)
        {
            var contact = _contactRepository.Get(id);
            if (contact == null)
            {
                return NotFound();
            }

            _contactRepository.UpdateContact(id, request);
            return NoContent();
        }
        //BORRAR CONTACTO
        [HttpDelete("{id}")]
        public ActionResult<Contact> Delete(Guid id)
        {
            var contact = _contactRepository.Get(id);
            if (contact == null)
            {
                return NotFound();
            }
            _contactRepository.Delete(id);
            return NoContent();
        }
        //FILTRAR POR CIUDAD
        [HttpGet("GetContactByCity/{name}")]
        public ActionResult GetCity(string name)
        {
            var contacts = _contactRepository.GetCity(name);
            if (contacts == null)
            {
                return NotFound();
            }

            return Ok(contacts);
        }

        //FILTRAR POR CIUDAD
        [HttpGet("GetContactByEmail/{email}")]
        public ActionResult<Contact> GetEmail(string email)
        {
            var contact = _contactRepository.GetEmail(email);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

    }
}
