using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Repositories;
using System.Net;

namespace Sistema_de_Gestion_Moras.Services
{
    public interface IMissionsService
    {
        Task<List<Missions>> GetAll();
        Task<Missions> GetMissions(int idMissions);
        Task<Missions> CreateMissions(string nameMission, string description, int idLevel);
        Task<Missions> UpdateMissions(int idMissions, string? nameMission=null, string? description=null, int? idLevel=null);
        Task<Missions> DeleteMissions(int idMissions);
    }

    public class MissionsService : IMissionsService
    {
        public readonly IMissionsRepository _missionsRepository;
        public MissionsService(IMissionsRepository missionsRepository)
        {
            _missionsRepository = missionsRepository;
        }

        public async Task<Missions> CreateMissions(string nameMission, string description, int idLevel)
        {
            return await _missionsRepository.CreateMissions(nameMission, description, idLevel);
            throw new NotImplementedException();
        }

        public async Task<Missions> DeleteMissions(int idMissions)
        {
            Missions MissionsToDelete = await _missionsRepository.GetMissions(idMissions);
            if (MissionsToDelete == null)
            {
                throw new Exception($"This Missions with the Id {idMissions} don´t exist. ");
            }
            MissionsToDelete.StateDelete = true;
            MissionsToDelete.ModifyDate = DateTime.Now;
            return await _missionsRepository.DeleteMissions(MissionsToDelete);
            throw new NotImplementedException();
        }

        public async Task<List<Missions>> GetAll()
        {
            return await _missionsRepository.GetAll();
            throw new NotImplementedException();
        }

        public async Task<Missions> GetMissions(int idMissions)
        {
            return await _missionsRepository.GetMissions(idMissions);
            throw new NotImplementedException();
        }

        public async Task<Missions> UpdateMissions(int idMissions, string? nameMission = null, string? description = null, int? idLevel = null)
        {
            Missions newMissions = await _missionsRepository.GetMissions(idMissions);
            if (newMissions != null)
            {

                if (nameMission != null)
                {
                    newMissions.NameMission = (string)nameMission;
                }
                if (description != null)
                {
                    newMissions.Description = (string)description;
                }
                if (idLevel != null)
                {
                    newMissions.IdLevel = (int)idLevel;
                }
                return await _missionsRepository.UpdateMissions(newMissions);
            }
            throw new NotImplementedException();
        }
    }
}
