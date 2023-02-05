using Core.ContactRepository.Interfaces;
using Data.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ApiContactBook.Controllers
{
    [Route("api/contact")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet]
        public ActionResult<List<Contact>> Get()
        {
            var contacts = _contactRepository.GetAll();
            if (contacts.Count != 0) return Ok(_contactRepository.GetAll());
            return StatusCode(204, "La lista de personas esta vacia");
        }

        [HttpGet("{id}")]
        public ActionResult<Contact> Get(int id)
        {
            var contact = _contactRepository.Get(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

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

        [HttpPost]
        public ActionResult<Contact> Post(Contact contact)
        {
            _contactRepository.Add(contact);
            return CreatedAtAction(nameof(Get), new { id = contact.ContactId }, contact);
        }

        [HttpPut("{id}")]
        public ActionResult<Contact> Put(int id, Contact contact)
        {
            if (id != contact.ContactId)
            {
                return BadRequest();
            }
            _contactRepository.Update(contact);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Contact> Delete(int id)
        {
            var contact = _contactRepository.Get(id);
            if (contact == null)
            {
                return NotFound();
            }
            _contactRepository.Delete(id);
            return NoContent();
        }
    }
}
