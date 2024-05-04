using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Repositories;
using System.Net;
namespace Sistema_de_Gestion_Moras.Services
{
    public interface ILandmarksService
    {
        Task<List<Landmarks>> GetAll();
        Task<Landmarks> GetLandmarks(int idLandmarks);
        Task<Landmarks> CreateLandmarks(int idLevel, int idHarvest, DateTime dateLandmark);
        Task<Landmarks> UpdateLandmarks(int idLandmarks, int? idLevel = null, int? idHarvest = null, DateTime? dateLandmark = null);
        Task<Landmarks> DeleteLandmarks(int idLandmarks);
    }
    public class LandmarksService : ILandmarksService
    {
        public readonly ILandmarksRepository _landmarksRepository;
        public LandmarksService(ILandmarksRepository landmarksRepository)
        {
            _landmarksRepository = landmarksRepository;
        }
        public async Task<Landmarks> CreateLandmarks(int idLevel, int idHarvest, DateTime dateLandmark)
        {
            return await _landmarksRepository.CreateLandmarks(idLevel, idHarvest, dateLandmark);
            throw new NotImplementedException();
        }

        public async Task<Landmarks> DeleteLandmarks(int idLandmarks)
        {
            Landmarks LandmarksToDelete = await _landmarksRepository.GetLandmarks(idLandmarks);
            if (LandmarksToDelete == null)
            {
                throw new Exception($"This Landmarks with the Id {idLandmarks} don´t exist. ");
            }
            LandmarksToDelete.StateDelete = true;
            LandmarksToDelete.ModifyDate = DateTime.Now;
            return await _landmarksRepository.DeleteLandmarks(LandmarksToDelete);
            throw new NotImplementedException();
        }

        public async Task<List<Landmarks>> GetAll()
        {
            return await _landmarksRepository.GetAll();
            throw new NotImplementedException();
        }

        public async Task<Landmarks> GetLandmarks(int idLandmarks)
        {
            return await _landmarksRepository.GetLandmarks(idLandmarks);
            throw new NotImplementedException();
        }

        public async Task<Landmarks> UpdateLandmarks(int idLandmarks, int? idLevel = null, int? idHarvest = null, DateTime? dateLandmark = null)
        {
            Landmarks newLandmarks = await _landmarksRepository.GetLandmarks(idLandmarks);
            if (newLandmarks != null)
            {

                if (idLevel != null)
                {
                    newLandmarks.IdLevel = (int)idLevel;
                }
                if (idHarvest != null)
                {
                    newLandmarks.IdHarvests = (int)idHarvest;
                }
                if (dateLandmark != null)
                {
                    newLandmarks.DateLandmark = (DateTime)dateLandmark;
                }
                return await _landmarksRepository.UpdateLandmarks(newLandmarks);
            }
            throw new NotImplementedException();
        }
    }
}
