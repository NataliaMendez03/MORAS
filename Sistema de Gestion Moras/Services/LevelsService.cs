using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Repositories;
using System.Net;

namespace Sistema_de_Gestion_Moras.Services
{
    public interface ILevelsService
    {
        Task<List<Levels>> GetAll();
        Task<Levels> GetLevels(int idLevels);
        Task<Levels> CreateLevels(string nameLevel);
        Task<Levels> UpdateLevels(int idLevels, string? nameLevel=null);
        Task<Levels> DeleteLevels(int idLevels);
    }

    public class LevelsService : ILevelsService
    {
        public readonly ILevelsRepository _levelsRepository;
        public LevelsService(ILevelsRepository levelsRepository)
        {
            _levelsRepository = levelsRepository;
        }

        public async Task<Levels> CreateLevels(string nameLevel)
        {
            return await _levelsRepository.CreateLevels(nameLevel);
            throw new NotImplementedException();
        }

        public async Task<Levels> DeleteLevels(int idLevels)
        {
            Levels levelsToDelete = await _levelsRepository.GetLevels(idLevels);
            if (levelsToDelete == null)
            {
                throw new Exception($"This level with the Id {idLevels} don´t exist. ");
            }
            levelsToDelete.StateDelete = true;
            levelsToDelete.ModifyDate = DateTime.Now;
            return await _levelsRepository.DeleteLevels(levelsToDelete);
            throw new NotImplementedException();
        }

        public async Task<List<Levels>> GetAll()
        {
            return await _levelsRepository.GetAll();
            throw new NotImplementedException();
        }

        public async Task<Levels> GetLevels(int idLevels)
        {
            return await _levelsRepository.GetLevels(idLevels);
            throw new NotImplementedException();
        }

        public async Task<Levels> UpdateLevels(int idLevels, string? nameLevel = null)
        {
            Levels newLevel = await _levelsRepository.GetLevels(idLevels);
            if (newLevel != null)
            {

                if (nameLevel != null)
                {
                    newLevel.NameLevel = (string)nameLevel;
                }
                
                return await _levelsRepository.UpdateLevels(newLevel);
            }
            throw new NotImplementedException();
        }
    }
}
