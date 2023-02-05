using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.ContactRepository.Interfaces;
using Data.Context;
using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Core.ContactRepository.Implementations
{
    public class ContactRepository : IContactRepository
    {
        private readonly MyDbContext _context;
        public ContactRepository(MyDbContext context)
        {
            _context = context;
        }
        public void Add(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var contact = _context.Contacts.Find(id);
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
        }

        public Contact Get(int id)
        {
            return _context.Contacts.Find(id);
        }

        public List<Contact> GetAll()
        {
            return _context.Contacts.ToList();
        }

        public Contact GetShuffle()
        {
            int count = _context.Contacts.Count();
            int randomId = new Random().Next(1, count + 1);
            Contact randomContact = _context.Contacts.Find(randomId);
            return randomContact;
        }

        public void Update(Contact contact)
        {
            _context.Entry(contact).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
