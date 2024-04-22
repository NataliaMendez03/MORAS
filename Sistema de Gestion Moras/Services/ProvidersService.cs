using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Repositories;

namespace Sistema_de_Gestion_Moras.Services
{
    public interface IProvidersService
    {
        Task<List<Providers>> GetAll();
        Task<Providers> GetProviders(int idProviders);
        Task<Providers> CreateProviders(int idPerson);
        Task<Providers> UpdateProviders(int idProviders, int idPerson);
        Task<Providers> DeleteProviders(int idProviders);
    }
    public class ProvidersService : IProvidersService
    {
        public readonly IProvidersRepository _ProvidersRepository;
        public ProvidersService(IProvidersRepository ProvidersRepository)
        {
            _ProvidersRepository = ProvidersRepository;
        }

        public async Task<Providers> CreateProviders(int idPerson)        {
            return await _ProvidersRepository.CreateProviders(idPerson);
            throw new NotImplementedException();
        }

        public async Task<Providers> DeleteProviders(int idProviders)
        {
            Providers ProvidersToDelete = await _ProvidersRepository.GetProviders(idProviders);
            if (ProvidersToDelete == null)
            {
                throw new Exception($"This Providers with the Id {idProviders} doesn´t exist. ");
            }
            ProvidersToDelete.StateDelete = true;
            ProvidersToDelete.ModifyDate = DateTime.Now;
            return await _ProvidersRepository.DeleteProviders(ProvidersToDelete);
            throw new NotImplementedException();
        }

        public async Task<List<Providers>> GetAll()
        {
            return await _ProvidersRepository.GetAll();
            throw new NotImplementedException();
        }

        public async Task<Providers> GetProviders(int idProviders)
        {
            return await _ProvidersRepository.GetProviders(idProviders);
            throw new NotImplementedException();
        }

        public async Task<Providers> UpdateProviders(int idProviders, int idPerson)
        {
            Providers newProviders = await _ProvidersRepository.GetProviders(idProviders);
            if (newProviders != null)
            {

                if (idPerson != null)
                {
                    newProviders.IdPerson = (int)idPerson;
                }

                return await _ProvidersRepository.UpdateProviders(newProviders);
            }
            throw new NotImplementedException();
        }
    }
}