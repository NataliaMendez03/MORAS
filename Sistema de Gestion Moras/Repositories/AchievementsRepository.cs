using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Context;
using Sistema_de_Gestion_Moras.Models;

namespace Sistema_de_Gestion_Moras.Repositories
{
    public interface IAchievementsRepository
    {
        Task<List<Achievements>> GetAll();
        Task<Achievements> GetAchievements(int idAchievements);
        Task<Achievements> CreateAchievements(int IdLogin, int IdMission, DateTime DateAchievement);
        Task<Achievements> UpdateAchievements(Achievements Achievements);
        Task<Achievements> DeleteAchievements(Achievements Achievements);
    }
    public class AchievementsRepository : IAchievementsRepository
    {
        private readonly berriesdbContext _db;
        public AchievementsRepository(berriesdbContext db)
        {
            _db = db;
        }
        public async Task<Achievements> CreateAchievements(int IdLogin, int IdMission, DateTime DateAchievement)
        {
            Login? Login = _db.Login.FirstOrDefault(ut => ut.IdLogin == IdLogin);
            Missions? Missions = _db.Missions.FirstOrDefault(ut => ut.IdMission == IdMission);

            Achievements newAchievements = new Achievements
            {
                IdLogin = IdLogin,
                IdMission = IdMission,
                DateAchievement = DateAchievement,
                StateDelete = false,
                ModifyDate = null
            };

            await _db.Achievements.AddAsync(newAchievements);
            _db.SaveChanges();

            return newAchievements;
        }

        public async Task<Achievements> DeleteAchievements(Achievements Achievements)
        {
            _db.Achievements.Attach(Achievements); //Llamamos la actualizacion
            _db.Entry(Achievements).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return Achievements;
        }

        public async Task<List<Achievements>> GetAll()
        {
            return await _db.Achievements.ToListAsync();
        }

        public async Task<Achievements> GetAchievements(int idAchievements)
        {
            return await _db.Achievements.FirstOrDefaultAsync(u => u.IdArchievement == idAchievements);
        }

        public async Task<Achievements> UpdateAchievements(Achievements Achievements)
        {
            Achievements AchievementsUpdate = await _db.Achievements.FindAsync(Achievements.IdArchievement);
            if (AchievementsUpdate != null)
            {
                AchievementsUpdate.IdLogin = Achievements.IdLogin;
                AchievementsUpdate.IdMission = Achievements.IdMission;
                AchievementsUpdate.DateAchievement = Achievements.DateAchievement;

                await _db.SaveChangesAsync();
            }
            return AchievementsUpdate;
        }
    }
}