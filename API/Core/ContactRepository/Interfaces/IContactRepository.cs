using Core.DTO;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.PersonRepository.Interfaces //ESTA ES UNA INTERFAZ QUE SERA IMPLEMENTADA EN EL REPOSITORIO DE CONTACTO
{
    public interface IContactRepository
    {
        Task <List<Contact>> GetEmail(string email);
        Task <List<Contact>> GetCity(string name);
        Task <Contact> Get(Guid id);
        Task <List<Contact>> GetShuffle();
        Task <List<Contact>> GetAll();
        Task AddContact(ContactDto request);
        Task UpdateContact(Guid id, ContactDto request);
        Task Delete(Guid id);
    }
}
