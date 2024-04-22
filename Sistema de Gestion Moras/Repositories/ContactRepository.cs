using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Context;
using Sistema_de_Gestion_Moras.Models;
using System.Net;

namespace Sistema_de_Gestion_Moras.Repositories
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetAll();
        Task<Contact> GetContact(int idContact);
        Task<Contact> CreateContact(string phone, string email);
        Task<Contact> UpdateContact(Contact contact);
        Task<Contact> DeleteContact(Contact contact);
    }
    public class ContactRepository : IContactRepository
    {
        private readonly berriesdbContext _db;
        public ContactRepository(berriesdbContext db)
        {
            _db = db;
        }
        public async Task<Contact> CreateContact(string phone, string email)
        {
            Contact newContact = new Contact
            {
                Phone = phone,
                Email = email,
                StateDelete = false,
                ModifyDate = null
            };

            await _db.Contact.AddAsync(newContact);
            _db.SaveChanges();

            return newContact;
        }

        public async Task<Contact> DeleteContact(Contact contact)
        {
            _db.Contact.Attach(contact); //Llamamos la actualizacion
            _db.Entry(contact).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return contact;
        }

        public async Task<List<Contact>> GetAll()
        {
            return await _db.Contact.ToListAsync();
        }

        public async Task<Contact> GetContact(int idContact)
        {
            return await _db.Contact.FirstOrDefaultAsync(u => u.IdContact == idContact);
        }

        public async Task<Contact> UpdateContact(Contact contact)
        {
            Contact ConsultUpdate = await _db.Contact.FindAsync(contact.IdContact);
            if (ConsultUpdate != null)
            {
                ConsultUpdate.Phone = contact.Phone;
                ConsultUpdate.Email = contact.Email;

                await _db.SaveChangesAsync();
            }
            return ConsultUpdate;
        }
    }
}
