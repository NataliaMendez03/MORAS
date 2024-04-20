
using Sistema_de_Gestion_Moras.Models;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Context;
using Sistema_de_Gestion_Moras.Repositories;
namespace Sistema_de_Gestion_Moras.Services
{
    public interface ISuppliesService
    {
        Task<List<Supplies>> GetAll(); 
        Task<Supplies> GetSupplies(int idSupplies);
        Task<Supplies> CreateSupplies(string nameSupplies);
        Task<Supplies> UpdateSupplies(int idSupplies, string? nameSupplies = null);
        Task<Supplies> DeleteSupplies(int idSupplies);
    }
    public class SuppliesService : ISuppliesService
    {
        public readonly ISuppliesRepository _suppliesRepository;
        public SuppliesService(ISuppliesRepository suppliesRepository)
        {
            _suppliesRepository = suppliesRepository;
        }

        public async Task<Supplies> CreateSupplies(string nameSupplies)
        {
            return await _suppliesRepository.CreateSupplies(nameSupplies);
            throw new NotImplementedException();
        }

        public async Task<Supplies> DeleteSupplies(int idSupplies)
        {
            Supplies SuppliesToDelete = await _suppliesRepository.GetSupplies(idSupplies);
            if (SuppliesToDelete == null)
            {
                throw new Exception($"This salesDetails with the Id {idSupplies} don´t exist. ");
            }
            SuppliesToDelete.StateDelete = true;
            SuppliesToDelete.CreatedDate = DateTime.Now;
            return await _suppliesRepository.DeleteSupplies(SuppliesToDelete);
            throw new NotImplementedException(); 
        }

        public async Task<List<Supplies>> GetAll()
        {
            return await _suppliesRepository.GetAll();
            throw new NotImplementedException();
        }

        public async Task<Supplies> GetSupplies(int idSupplies)
        {
            return await _suppliesRepository.GetSupplies(idSupplies);
            throw new NotImplementedException();
        }

        public async Task<Supplies> UpdateSupplies(int idSupplies, string?  nameSupplies = null)
        {
            Supplies newSupplies = await _suppliesRepository.GetSupplies(idSupplies);
            if (newSupplies != null)
            {

                if (nameSupplies != null)
                {
                    newSupplies.NameSupplies = (string)nameSupplies;
                }

                return await _suppliesRepository.UpdateSupplies(newSupplies);
            }
            throw new NotImplementedException();
        }
    }
}
