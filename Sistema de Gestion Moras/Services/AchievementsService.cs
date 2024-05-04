using Sistema_de_Gestion_Moras.Context;
using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Repositories;

namespace Sistema_de_Gestion_Moras.Services
{
    

    public interface IAchievementsService
    {
        Task<List<Achievements>> GetAll();
        Task<Achievements> GetAchievements(int idAchievements);
        Task<Achievements> CreateAchievements(int IdLogin, int IdMission, DateTime DateAchievement);
        Task<Achievements> UpdateAchievements(int idAchievements, int? idLogin = null, int? IdMission = null, DateTime? DateAchievement = null);
        Task<Achievements> DeleteAchievements(int idAchievements);
    }

    public class AchievementsService : IAchievementsService
    {
        public readonly IAchievementsRepository _AchievementsRepository;
        public AchievementsService(IAchievementsRepository AchievementsRepository)
        {
            _AchievementsRepository = AchievementsRepository;
        }
        public async Task<Achievements> CreateAchievements(int idLogin, int IdMission, DateTime DateAchievement)
        {
            return await _AchievementsRepository.CreateAchievements(idLogin, IdMission, DateAchievement);
            throw new NotImplementedException();
        }

        public async Task<Achievements> DeleteAchievements(int idAchievements)
        {
            Achievements AchievementsToDelete = await _AchievementsRepository.GetAchievements(idAchievements);
            if (AchievementsToDelete == null)
            {
                throw new Exception($"This Achievements with the Id {idAchievements} don´t exist. ");
            }
            AchievementsToDelete.StateDelete = true;
            AchievementsToDelete.ModifyDate = DateTime.Now;
            return await _AchievementsRepository.DeleteAchievements(AchievementsToDelete);
            throw new NotImplementedException();
        }

        public async Task<Achievements> GetAchievements(int idAchievements)
        {
            return await _AchievementsRepository.GetAchievements(idAchievements);
            throw new NotImplementedException();
        }

        public async Task<List<Achievements>> GetAll()
        {
            return await _AchievementsRepository.GetAll();
            throw new NotImplementedException();
        }

        public async Task<Achievements> UpdateAchievements(int idAchievements, int? idLogin = null, int? IdMission = null, DateTime? DateAchievement = null)
        {
            Achievements newAchievements = await _AchievementsRepository.GetAchievements(idAchievements);
            if (newAchievements != null)
            {

                if (idLogin != null)
                {
                    newAchievements.IdArchievement = (int)idLogin;
                }
                if (IdMission != null)
                {
                    newAchievements.IdMission = (int)IdMission;
                }
                if (DateAchievement != null)
                {
                    newAchievements.DateAchievement = (DateTime)DateAchievement;
                }
                return await _AchievementsRepository.UpdateAchievements(newAchievements);
            }
            throw new NotImplementedException();
        }
    }
}
