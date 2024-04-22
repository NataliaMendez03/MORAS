using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Repositories;

namespace Sistema_de_Gestion_Moras.Services
{
    public interface IProvidervsInputsService
    {
        Task<List<ProvidervsInputs>> GetAll();
        Task<ProvidervsInputs> GetProvidervsInputs(int idProvsInp);
        Task<ProvidervsInputs> CreateProvidervsInputs(int idProviders, int idSupplies);
        Task<ProvidervsInputs> UpdateProvidervsInputs(int idProvsInp, int? idProviders=null, int? idSupplies=null);
        Task<ProvidervsInputs> DeleteProvidervsInputs(int idProvsInp);
    }
    public class ProvidervsInputsService : IProvidervsInputsService
    {
        public readonly IProvidervsInputsRepository _ProvidervsInputsRepository;
        public ProvidervsInputsService(IProvidervsInputsRepository ProvidervsInputsRepository)
        {
            _ProvidervsInputsRepository = ProvidervsInputsRepository;
        }

        public async Task<ProvidervsInputs> CreateProvidervsInputs(int idProviders, int idSupplies)
        {
            return await _ProvidervsInputsRepository.CreateProvidervsInputs(idProviders, idSupplies);
            throw new NotImplementedException();
        }

        public async Task<ProvidervsInputs> DeleteProvidervsInputs(int idProvsInp)
        {
            ProvidervsInputs ProvidervsInputsToDelete = await _ProvidervsInputsRepository.GetProvidervsInputs(idProvsInp);
            if (ProvidervsInputsToDelete == null)
            {
                throw new Exception($"This ProvidervsInputs with the Id {idProvsInp} doesn´t exist. ");
            }
            ProvidervsInputsToDelete.StateDelete = true;
            ProvidervsInputsToDelete.ModifyDate = DateTime.Now;
            return await _ProvidervsInputsRepository.DeleteProvidervsInputs(ProvidervsInputsToDelete);
            throw new NotImplementedException();
        }

        public async Task<List<ProvidervsInputs>> GetAll()
        {
            return await _ProvidervsInputsRepository.GetAll();
            throw new NotImplementedException();
        }

        public async Task<ProvidervsInputs> GetProvidervsInputs(int idProvsInp)
        {
            return await _ProvidervsInputsRepository.GetProvidervsInputs(idProvsInp);
            throw new NotImplementedException();
        }

        public async Task<ProvidervsInputs> UpdateProvidervsInputs(int idProvsInp, int? idProviders = null, int? idSupplies = null)
        {
            ProvidervsInputs newProvidervsInputs = await _ProvidervsInputsRepository.GetProvidervsInputs(idProvsInp);
            if (newProvidervsInputs != null)
            {

                if (idProviders != null)
                {
                    newProvidervsInputs.IdProvsInp = (int)idProviders;
                }
                if (idSupplies != null)
                {
                    newProvidervsInputs.IdSupplies = (int)idSupplies;
                }
              
                return await _ProvidervsInputsRepository.UpdateProvidervsInputs(newProvidervsInputs);
            }
            throw new NotImplementedException();
        }
    }
}