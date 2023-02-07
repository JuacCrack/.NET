using Data.Models;
using System;
using System.Collections.Generic;

namespace Core.PersonRepository.Interfaces
{
    public interface IContactRepository
    {
        List<Contact> GetEmail(string email);
        List<Contact> GetCity(string name);
        Contact Get(Guid id);
        Contact GetShuffle();
        List<Contact> GetAll();
        void AddContact(AddContactRequest request);
        void UpdateContact(Guid id, UpdateContactRequest request);
        void Delete(Guid id);
    }
}
