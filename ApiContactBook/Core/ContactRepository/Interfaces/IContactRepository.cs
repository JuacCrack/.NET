using System;
using System.Collections.Generic;
using System.Text;
using Data.Model;

namespace Core.ContactRepository.Interfaces
{
    public interface IContactRepository
    {
        Contact Get(int id);
        Contact GetShuffle();
        List<Contact> GetAll();
        void Add(Contact contact);
        void Update(Contact contact);
        void Delete(int id);
    }
}
