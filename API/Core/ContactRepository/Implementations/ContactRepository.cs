using Core.PersonRepository.Interfaces;
using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Core.PersonRepository.Implementations
{
    public class ContactRepository : IContactRepository
    {
        private readonly MyDbContext _context;
        public ContactRepository(MyDbContext context)
        {
            _context = context;
        }
        //AGREGAR CONTACTO
        public void AddContact(AddContactRequest request)
        {
            var contact = new Contact
            {
                ContactId = Guid.NewGuid(),
                name = request.name,
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

            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }


        //BORRAR CONTACTO
        public void Delete(Guid id)
        {
            var contact = _context.Contacts.Find(id);
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
        }

        //TRAER CONTACTO POR ID
        public Contact Get(Guid id)
        {
            return _context.Contacts.Find(id);
        }
        //TRAER TODOS LOS CONTACTOS
        public List<Contact> GetAll()
        {
            return _context.Contacts.Include(c => c.City).ToList();
        }
        //TRAER ALEATORIAMENTE
        public Contact GetShuffle()
        {
            int count = _context.Contacts.Count();
            int randomId = new Random().Next(1, count + 1);
            Contact randomContact = _context.Contacts.Find(randomId);
            return randomContact;
        }
        //ACTUALIZAR CONTACTO
        public void UpdateContact(Guid id, UpdateContactRequest request)
        {
            var contact = _context.Contacts.Find(id);
            if (contact == null)
            {
                return;
            }

            contact.name = request.name;
            contact.company = request.company;
            contact.profile = request.profile;
            contact.image = request.image;
            contact.email = request.email;
            contact.birthdate = request.birthdate;
            contact.phonew = request.phonew;
            contact.phonep = request.phonep;
            contact.address = request.address;
            contact.CityFK = request.CityFK;

            _context.Contacts.Update(contact);
            _context.SaveChanges();
        }
        //TRAER CONTACTO POR EMAIL
        public List<Contact> GetEmail(string email)
        {
            var contacts = _context.Contacts.Include(c => c.City)
                                             .Where(c => c.email.Contains(email))
                                             .ToList();
            return contacts;
        }

        //TRAER CONTACTO POR CIUDAD
        public List<Contact> GetCity(string name)
        {
            var contacts = _context.Contacts.Include(c => c.City)
                                     .Where(c => c.City.name.Contains(name))
                                     .ToList();
            return contacts;
        }


    }
}

