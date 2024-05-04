using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Context;
using Sistema_de_Gestion_Moras.Models;
using System.Net.Sockets;

namespace Sistema_de_Gestion_Moras.Repositories
{
    public interface IMissionsRepository
    {
        Task<List<Missions>> GetAll();
        Task<Missions> GetMissions(int idMissions);
        Task<Missions> CreateMissions(string nameMission, string description, int idLevel);
        Task<Missions> UpdateMissions(Missions Missions);
        Task<Missions> DeleteMissions(Missions Missions);
    }
    public class MissionsRepository : IMissionsRepository
    {
        private readonly berriesdbContext _db;
        public MissionsRepository(berriesdbContext db)
        {
            _db = db;
        }
        public async Task<Missions> CreateMissions(string nameMission, string description, int idLevel)
        {
            Levels? levels = _db.Levels.FirstOrDefault(ut => ut.IdLevel == idLevel);

            Missions newMissions = new Missions
            {
                NameMission = nameMission,
                Description = description,
                IdLevel = idLevel,
                StateDelete = false,
                ModifyDate = null
            };

            await _db.Missions.AddAsync(newMissions);
            _db.SaveChanges();

            return newMissions;
        }

        public async Task<Missions> DeleteMissions(Missions Missions)
        {
            _db.Missions.Attach(Missions); //Llamamos la actualizacion
            _db.Entry(Missions).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return Missions;
        }

        public async Task<List<Missions>> GetAll()
        {
            return await _db.Missions.ToListAsync();
        }

        public async Task<Missions> GetMissions(int idMissions)
        {
            return await _db.Missions.FirstOrDefaultAsync(u => u.IdMission == idMissions);
        }

        public async Task<Missions> UpdateMissions(Missions Missions)
        {
            Missions MissionsUpdate = await _db.Missions.FindAsync(Missions.IdMission);
            if (MissionsUpdate != null)
            {
                MissionsUpdate.NameMission = Missions.NameMission;
                MissionsUpdate.Description = Missions.Description;
                MissionsUpdate.IdLevel = Missions.IdLevel;

                await _db.SaveChangesAsync();
            }
            return MissionsUpdate;
        }
    }
}