using Core.PersonRepository.Interfaces;
using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTO;

namespace Core.PersonRepository.Implementations
{
    public class ContactRepository : IContactRepository //ESTA IMPLEMENTACION UTILIZA LA INTERFAZ DE CONTACT REPOSITORIO
    {
        private readonly MyDbContext _context; //CONSTRUCTOR PRIVADO DEL DB CONTEXT QUE UTILIZA EL PARAMETRO _context
        public ContactRepository(MyDbContext context)//CONSTRUCTOR DE CONTACT REPOSITORIO QUE IMPLEMENTA EL DBCONTEXT EN UN PARAMETRO _context9
        {
            _context = context; 
        }
        //AGREGAR CONTACTO
        public async Task AddContact(ContactDto request)
        {
            var contact = new Contact //NUEVO MODELO DE CONTACT
            {
                //UTILIZAMOS EL MODELO REQUEST PARA CARGAR AL MODELO CONTACT
                fullname = request.fullname,
                company = request.company,
                profile = request.profile,
                image = request.image,
                email = request.email,
                birthdate = request.birthdate,
                phonew = request.phonew,
                phonep = request.phonep,
                address = request.address,
                CityFK = request.CityFK
            };

            await _context.Contacts.AddAsync(contact);//AGREGAMOS LOS CAMBIOS A CONTACT
           await _context.SaveChangesAsync();//Y GUARDAMOS LOS CAMBIOS
        }


        //BORRAR CONTACTO
        public async Task Delete(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);//BUSCAMOS LA ID DE LA RUTA
            _context.Contacts.Remove(contact);//UTILIZAMOS EL DBCONTEXT PARA BORRAR EL CONTACTO DE LA DB
           await _context.SaveChangesAsync();//GUARDAMOS LOS CAMBIOS
        }

        //TRAER CONTACTO POR ID
        public async Task<Contact> Get(int id)
        {
            return await _context.Contacts.FindAsync(id);//UTILIZAMOS LA ID DE LA RUTA PARA DEVOLVER UN CONTACTO SEGUN LA ID
        }
        //TRAER TODOS LOS CONTACTOS
        public async Task<List<Contact>> GetAll()
        {
            return await _context.Contacts.Include(c => c.City).ToListAsync();//DEVOLVEMOS TODA LA LISTA CONTACT INCLUYENDO EL MODELO CITY EN FORMA DE LISTA
        }
        //TRAER ALEATORIAMENTE
        public async Task<List<Contact>> GetShuffle()
        {
            List<Contact> contacts = await _context.Contacts.ToListAsync();
            int count = contacts.Count();
            if (count == 0)
            {
                return null;
            }
            int randomIndex = new Random().Next(0, count);
            int randomId = contacts[randomIndex].ContactId;
            Contact randomContact = await _context.Contacts.FirstOrDefaultAsync(c => c.ContactId == randomId);
            List<Contact> result = new List<Contact> { randomContact };
            return result;
        }
        //ACTUALIZAR CONTACTO
        public async Task UpdateContact(int id, ContactDto request)
        {
            var contact = await _context.Contacts.FindAsync(id);//UTILIZAMOS LA RUTA PARA BUSCAR UNA ID
            if (contact == null)
            {
                return; //SI LA ID ES NULA HACEMOS UNA DEVOLUCION
            }
            //SI LA ID EXISTE UTILIZAMOS EL REQUEST PARA CARGAR LOS DATOS DEL MODELO CONTACT
            contact.fullname = request.fullname;
            contact.company = request.company;
            contact.profile = request.profile;
            contact.image = request.image;
            contact.email = request.email;
            contact.birthdate = request.birthdate;
            contact.phonew = request.phonew;
            contact.phonep = request.phonep;
            contact.address = request.address;
            contact.CityFK = request.CityFK;

            _context.Contacts.Update(contact);//ACTUALIZAMOS EL MODELO DE CONTACTO DE LA ID BUSCADA
            await _context.SaveChangesAsync();//GUARDAMOS LOS CAMBIOS
        }
        //TRAER CONTACTO POR EMAIL
        public async Task<List<Contact>> GetEmail(string email)
        {
            var contacts = await _context.Contacts.Include(c => c.City)
                                             .Where(c => c.email.Contains(email))
                                             .ToListAsync();//BUSCAMOS EN LA TABLA CONTACT Y CITY DONDE LA COLUMNA EMAIL CONTENGA EL STRING DE LA RUTA
            return contacts;//DEVUELVE EL O LOS CONTACTO CON EL EMAIL SOLICITADO
        }

        //TRAER CONTACTO POR CIUDAD
        public async Task<List<Contact>> GetCity(string name)
        {
            var contacts = await _context.Contacts.Include(c => c.City)
                                     .Where(c => c.City.name.Contains(name))
                                     .ToListAsync();//BUSCAMOS EN LA TABLA CONTACT Y CITY DONDE LA COLUMNA CITY CONTENGA EL STRING DE LA RUTA
            return contacts;//DEVUELVE EL O LOS CONTACTO CON LA CITY SOLICITADO
        }


    }
}

