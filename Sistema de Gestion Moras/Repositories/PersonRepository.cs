
using Sistema_de_Gestion_Moras.Models;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Context;
namespace Sistema_de_Gestion_Moras.Repositories
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetAll();
        Task<Person> GetPerson(int idPerson); 
        Task<Person> CreatePerson(string name, string lastName, int idContact, int idTypeIdentification, int numberIdentification, int idAddress);
        Task<Person> UpdatePerson(Person person);
        Task<Person> DeletePerson(Person person);
    }
    public class PersonRepository: IPersonRepository
    {
        private readonly berriesdbContext _db;
        public PersonRepository(berriesdbContext db)
        {
            _db = db;
        }

        public async Task<Person> CreatePerson(string name, string lastName, int idContact, int idTypeIdentification, int numberIdentification, int idAddress)
        {
            Contact? contact = _db.Contact.FirstOrDefault(ut => ut.IdContact == idContact);
            IdentificationType? identificationType = _db.IdentificationType.FirstOrDefault(ut => ut.IdIdentificationType == idTypeIdentification);
            Address? address = _db.Address.FirstOrDefault(ut => ut.IdAddress == idAddress);

            Person newPerson = new Person
            {
                Name = name,
                LastName = lastName,
                IdContact = idContact,
                IdTypeIdentification = idTypeIdentification,
                NumberIdentification = numberIdentification,
                IdAddress = idAddress,
                StateDelete = false,
                CreatedDate = null
            };

            await _db.Person.AddAsync(newPerson);
            _db.SaveChanges();
            return newPerson;
            throw new NotImplementedException();
        }

        public async Task<Person> DeletePerson(Person person)
        {
            _db.Person.Attach(person); //Llamamos la actualizacion
            _db.Entry(person).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return person;
            throw new NotImplementedException();
        }

        public async Task<List<Person>> GetAll()
        {
            return await _db.Person.ToListAsync(); 
            throw new NotImplementedException();
        }

        public async Task<Person> GetPerson(int idPerson)
        {
            return await _db.Person.FirstOrDefaultAsync(u => u.IdPerson == idPerson);
            throw new NotImplementedException();
        }

        public async Task<Person> UpdatePerson(Person person)
        {
            Person ConsultUpdate = await _db.Person.FindAsync(person.IdPerson);
            if (ConsultUpdate != null)
            {
                ConsultUpdate.Name = person.Name;
                ConsultUpdate.LastName = person.LastName;
                ConsultUpdate.IdAddress = person.IdAddress;
                ConsultUpdate.IdContact = person.IdContact;
                ConsultUpdate.IdTypeIdentification = person.IdTypeIdentification;
                ConsultUpdate.NumberIdentification = person.NumberIdentification;
                await _db.SaveChangesAsync();
            }

            return ConsultUpdate;
            throw new NotImplementedException();
        }
    }
}
