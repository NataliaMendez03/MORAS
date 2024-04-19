using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Repositories;
using System.Net;

namespace Sistema_de_Gestion_Moras.Services
{
    public interface IContactService
    {
        Task<List<Contact>> GetAll();
        Task<Contact> GetContact(int idContact);
        Task<Contact> CreateContact(string phone, string email);
        Task<Contact> UpdateContact(int idContact, string? phone=null, string? email=null);
        Task<Contact> DeleteContact(int idContact);
    }
    public class ContactService: IContactService
    {
        public readonly IContactRepository _contactRepository;
        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<Contact> CreateContact(string phone, string email)
        {
            return await _contactRepository.CreateContact(phone, email);
        }

        public async Task<Contact> DeleteContact(int idContact)
        {
            // comprobar si existe
            Contact contactToDelete = await _contactRepository.GetContact(idContact);
            if (contactToDelete == null)
            {
                throw new Exception($"This Contact with the Id {idContact} don´t exist. ");
            }
            contactToDelete.StateDelete = true;
            contactToDelete.CreatedDate = DateTime.Now;
            return await _contactRepository.DeleteContact(contactToDelete);
        }

        public async Task<List<Contact>> GetAll()
        {
            return await _contactRepository.GetAll();
        }

        public async Task<Contact> GetContact(int idContact)
        {
            return await _contactRepository.GetContact(idContact);
        }

        public async Task<Contact> UpdateContact(int idContact, string? phone = null, string? email = null)
        {
            Contact newContact = await _contactRepository.GetContact(idContact);
            if (newContact != null)
            {
                if (phone != null)
                {
                    newContact.Phone = (string)phone;
                }
                if (email != null)
                {
                    newContact.Email = (string)email;
                }
                return await _contactRepository.UpdateContact(newContact);
            }
            throw new NotImplementedException();
        }
    }
}
