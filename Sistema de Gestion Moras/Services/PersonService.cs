using Sistema_de_Gestion_Moras.Models;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Context;
using Sistema_de_Gestion_Moras.Repositories;
namespace Sistema_de_Gestion_Moras.Services
{
    public interface IPersonService
    {
        Task<List<Person>> GetAll();
        Task<Person> GetPerson(int idPerson); 
        Task<Person> CreatePerson(string name, string lastName, int idContact, int idTypeIdentification, int numberIdentification, int idAddress);
        Task<Person> UpdatePerson(int idPerson, string? name = null, string? lastName = null, int? idContact = null, int? idTypeIdentification = null,int? numberIdentification = null, int? idAddress = null);
        Task<Person> DeletePerson(int idPerson);
    }
    public class PersonService : IPersonService
    {
        public readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Person> CreatePerson(string name, string lastName, int idContact, int idTypeIdentification, int numberIdentification, int idAddress)
        {
            return await _personRepository.CreatePerson(name,lastName, idContact, idTypeIdentification, numberIdentification, idAddress);
            throw new NotImplementedException();
        }

        public async Task<Person> DeletePerson(int idPerson)
        {
            Person PersonToDelete = await _personRepository.GetPerson(idPerson);
            if (PersonToDelete == null)
            {
                throw new Exception($"This person with the Id {idPerson} doesn´t exist. ");
            }
            PersonToDelete.StateDelete = true;
            PersonToDelete.ModifyDate = DateTime.Now;
            return await _personRepository.DeletePerson(PersonToDelete);
            throw new NotImplementedException();
        }

        public async Task<List<Person>> GetAll()
        {
            return await _personRepository.GetAll();
            throw new NotImplementedException();
        }

        public async Task<Person> GetPerson(int idPerson)
        {
            return await _personRepository.GetPerson(idPerson);
            throw new NotImplementedException();
        }

        public async Task<Person> UpdatePerson(int idPerson, string? name = null, string? lastName = null, int? idContact = null, int? idTypeIdentification = null, int? numberIdentification = null, int? idAddress = null)
        {
            Person newPerson = await _personRepository.GetPerson(idPerson);
            if (newPerson != null)
            {

                if (name != null)
                {
                    newPerson.Name = (string)name;
                }
                if (lastName != null)
                {
                    newPerson.LastName = (string)lastName;
                }
                if (idContact != null)
                {
                    newPerson.IdContact = (int)idContact;
                }
                if (idTypeIdentification != null)
                {
                    newPerson.IdTypeIdentification = (int)idTypeIdentification;
                }
                if(numberIdentification != null)
                {
                    newPerson.NumberIdentification = (int)numberIdentification;
                }
                if(idAddress != null)
                {
                    newPerson.IdAddress = (int)idAddress;
                }

                return await _personRepository.UpdatePerson(newPerson);
            }
            throw new NotImplementedException();
        }
    }
}
