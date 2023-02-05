using ContactsAPI.Data;
using ContactsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly DbContextAPI dbContext;

        public ContactsController(DbContextAPI dbContext)
        {
            this.dbContext = dbContext;
        }



        //TRAER TODO
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            try
            {

                var contactos = await dbContext.Contacts.Include(c => c.City).ToListAsync();


                if (contactos.Count == 0) {
                    return StatusCode(204, ("LISTA VACIA"));
                }


                return Ok(contactos);


            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


        }


        //TRAER POR ID
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetContact([FromRoute] int id)
        {
            var contact = await dbContext.Contacts.Include(c => c.City).FirstOrDefaultAsync(c => c.ContactId == id);

            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        //CARGAR CONTACTO
        [HttpPost]
        public async Task<IActionResult> AddContact(AddContactRequest addContactRequest)
        {

            try
            {
                var contact = new Contact()
                {

                    name = addContactRequest.name,
                    company = addContactRequest.company,
                    profile = addContactRequest.profile,
                    image = addContactRequest.image,
                    email = addContactRequest.email,
                    birthdate = addContactRequest.birthdate,
                    phonew = addContactRequest.phonew,
                    phonep = addContactRequest.phonep,
                    address = addContactRequest.address,
                    CityFK = addContactRequest.CityFK

                };

                if (await Idexists(contact.CityFK)==false)
                {
                    return StatusCode(400, ("NO SE ENONTRO LA CIUDAD"));
                }

                await dbContext.Contacts.AddAsync(contact);
                await dbContext.SaveChangesAsync();

                return Ok(contact);



            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        //VALIDAR ID
        private async Task<bool> Idexists(int CityFK)
        {
            var contact = await dbContext.Cities.FirstOrDefaultAsync(c => c.CityId == CityFK);
            return contact != null;
        }
        


        //ACTUALIZAR CONTACTO
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateContact([FromRoute] int id, UpdateContactRequest updateContactRequest)
        {
            var contact = await dbContext.Contacts.FindAsync(id);

            if (contact != null)
            {

                contact.name = updateContactRequest.name;
                contact.company = updateContactRequest.company;
                contact.profile = updateContactRequest.profile;
                contact.image = updateContactRequest.image;
                contact.email = updateContactRequest.email;
                contact.birthdate = updateContactRequest.birthdate;
                contact.phonew = updateContactRequest.phonew;
                contact.phonep = updateContactRequest.phonep;
                contact.address = updateContactRequest.address;
                contact.CityFK = updateContactRequest.CityFK;

                if (await Idexists(contact.CityFK) == false)
                {
                    return StatusCode(400, ("NO SE ENONTRO LA CIUDAD"));
                }

                await dbContext.SaveChangesAsync();

                return Ok(contact);

            }
            return NotFound();

        }

        //ELIMINAR CONTACTO
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteContact([FromRoute] int id)
        {
            var contact = await dbContext.Contacts.FindAsync(id);

            if (contact != null)
            {
                dbContext.Remove(contact);
                await dbContext.SaveChangesAsync();
                return Ok(contact);
            }

            return NotFound();
        }

        //FILTRAR POR EMAIL

        [HttpGet]
        [Route("{email}")]
        public async Task<IActionResult> GetEmail([FromRoute] string email)
        {

            try
            {

                var contact = await dbContext.Contacts.Include(c => c.City).FirstOrDefaultAsync(c => c.email.Contains(email));

                if (contact == null)
                {
                    return NotFound();
                }
                return Ok(contact);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //TRAER POR CIUDAD
        [HttpGet]
        [Route("api/{name}")]
        public async Task<IActionResult> GetCity([FromRoute] string name)
        {

            try
            {

                var contact = await dbContext.Contacts.Include(c => c.City).FirstOrDefaultAsync(c => c.City.name.Contains(name));

                if (contact == null)
                {
                    return NotFound();
                }
                return Ok(contact);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}

