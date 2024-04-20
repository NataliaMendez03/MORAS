using Sistema_de_Gestion_Moras.Models;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Context;
using Sistema_de_Gestion_Moras.Repositories;
namespace Sistema_de_Gestion_Moras.Services
{
    public interface IHarvestsService
    {
        Task<List<Harvests>> GetAll();
        Task<Harvests> GetHarvests(int idHarvests); 
        Task<Harvests> CreateHarvests(DateTime harvestDate, string harvestAmount, int idemployees, int idQuality);
        Task<Harvests> UpdateHarvests(int idHarvests,DateTime harvestDate, string harvestAmount, int idemployees, int idQuality);
        Task<Harvests> DeleteHarvests(int idHarvests);
    }
    public class HarvestsService : IHarvestsService
    {
        public readonly IHarvestsRepository _harvestsRepository;
        public HarvestsService(IHarvestsRepository harvestsRepository)
        {
            _harvestsRepository = harvestsRepository;
        }

        public async Task<Harvests> CreateHarvests(DateTime harvestDate, string harvestAmount, int idemployees, int idQuality)
        {
            return await _harvestsRepository.CreateHarvests(harvestDate, harvestAmount, idemployees, idQuality);
            throw new NotImplementedException();
        }

        public async Task<Harvests> DeleteHarvests(int idHarvests)
        {
            Harvests HarvestsToDelete = await _harvestsRepository.GetHarvests(idHarvests);
            if (HarvestsToDelete == null)
            {
                throw new Exception($"This harvests with the Id {idHarvests} don´t exist. ");
            }
            HarvestsToDelete.StateDelete = true;
            HarvestsToDelete.CreatedDate = DateTime.Now;
            return await _harvestsRepository.DeleteHarvests(HarvestsToDelete);
            throw new NotImplementedException();
        }

        public async Task<List<Harvests>> GetAll()
        {
            return await _harvestsRepository.GetAll();
            throw new NotImplementedException();
        }

        public async Task<Harvests> GetHarvests(int idHarvests)
        {
            return await _harvestsRepository.GetHarvests(idHarvests);
            throw new NotImplementedException();
        }

        public async Task<Harvests> UpdateHarvests(int idHarvests, DateTime harvestDate, string harvestAmount, int idemployees, int idQuality)
        {
            Harvests newHarvests = await _harvestsRepository.GetHarvests(idHarvests);
            if (newHarvests != null)
            {

                if (harvestDate != null)
                {
                    newHarvests.HarvestDate = (DateTime)harvestDate;
                }
                if (harvestAmount != null)
                {
                    newHarvests.HarvestAmount = (string)harvestAmount;
                }
                if (idemployees != null)
                {
                    newHarvests.Idemployees = (int)idemployees;
                }
                if (idQuality != null)
                {
                    newHarvests.IdQuality = (int)idQuality;
                }

                return await _harvestsRepository.UpdateHarvests(newHarvests);
            }
            throw new NotImplementedException();
        }
    }
}
