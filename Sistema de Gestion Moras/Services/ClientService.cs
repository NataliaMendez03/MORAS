using Sistema_de_Gestion_Moras.Models;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Context;
using Sistema_de_Gestion_Moras.Repositories;
namespace Sistema_de_Gestion_Moras.Services
{
    public interface IClientService
    {
        Task<List<Client>> GetAll();
        Task<Client> GetClient(int idClient); 
        Task<Client> CreateClient(int idPerson);
        Task<Client> UpdateClient(int idClient, int? idPerson = null);
        Task<Client> DeleteClient(int idClient);
    }
    public class ClientService : IClientService
    {
        public readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Client> CreateClient(int idPerson)
        {
            return await _clientRepository.CreateClient(idPerson);
            throw new NotImplementedException();
        }

        public async Task<Client> DeleteClient(int idClient)
        {
            Client ClientToDelete = await _clientRepository.GetClient(idClient);
            if (ClientToDelete == null)
            {
                throw new Exception($"This client with the Id {idClient} don´t exist. ");
            }
            ClientToDelete.StateDelete = true;
            ClientToDelete.ModifyDate = DateTime.Now;
            return await _clientRepository.DeleteClient(ClientToDelete);
            throw new NotImplementedException();
        }

        public async Task<List<Client>> GetAll()
        {
            return await _clientRepository.GetAll();
            throw new NotImplementedException();
        }

        public async Task<Client> GetClient(int idClient)
        {
            return await _clientRepository.GetClient(idClient);
            throw new NotImplementedException();
        }

        public async Task<Client> UpdateClient(int idClient, int? idPerson = null)
        {
            Client newClient = await _clientRepository.GetClient(idClient);
            if (newClient != null)
            {

                if (idPerson != null)
                {
                    newClient.IdPerson = (int)idPerson;
                }


                return await _clientRepository.UpdateClient(newClient);
            }
            throw new NotImplementedException();
        }
    }
}
