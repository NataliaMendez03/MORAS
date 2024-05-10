using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Context;
using Sistema_de_Gestion_Moras.Models;
using System.Net.Sockets;

namespace Sistema_de_Gestion_Moras.Repositories
{
    public interface ILandmarksRepository
    {
        Task<List<Landmarks>> GetAll();
        Task<Landmarks> GetLandmarks(int idLandmarks);
        Task<Landmarks> CreateLandmarks(int idLevel, int idHarvest);
        Task<Landmarks> UpdateLandmarks(Landmarks landmarks);
        Task<Landmarks> DeleteLandmarks(Landmarks landmarks);
    }
    public class LandmarksRepository : ILandmarksRepository
    {
        private readonly berriesdbContext _db;
        public LandmarksRepository(berriesdbContext db)
        {
            _db = db;
        }
        public async Task<Landmarks> CreateLandmarks(int idLevel, int idHarvest)
        {
            Harvests? harvests = _db.Harvests.FirstOrDefault(ut => ut.IdHarvests== idHarvest);
            Levels? levels = _db.Levels.FirstOrDefault(ut => ut.IdLevel == idLevel);

            Landmarks newLadmarks = new Landmarks
            {
                IdHarvests = idHarvest,
                IdLevel = idLevel,
                DateLandmark = DateTime.Now,
                StateDelete = false,
                ModifyDate = null
            };

            await _db.Landmarks.AddAsync(newLadmarks);
            _db.SaveChanges();

            return newLadmarks;
            throw new NotImplementedException();
        }

        public async Task<Landmarks> DeleteLandmarks(Landmarks landmarks)
        {
            _db.Landmarks.Attach(landmarks); //Llamamos la actualizacion
            _db.Entry(landmarks).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return landmarks;
            throw new NotImplementedException();
        }

        public async Task<List<Landmarks>> GetAll()
        {
            return await _db.Landmarks.ToListAsync();
        }

        public async Task<Landmarks> GetLandmarks(int idLandmarks)
        {
            return await _db.Landmarks.FirstOrDefaultAsync(u => u.IdLandmarks == idLandmarks);
        }

        public async Task<Landmarks> UpdateLandmarks(Landmarks landmarks)
        {
            Landmarks LandmarksUpdate = await _db.Landmarks.FindAsync(landmarks.IdLandmarks);
            if (LandmarksUpdate != null)
            {
                LandmarksUpdate.IdLevel = landmarks.IdLevel;
                LandmarksUpdate.IdHarvests = landmarks.IdHarvests;
         

                await _db.SaveChangesAsync();
            }
            return LandmarksUpdate;
        }
    }
}
