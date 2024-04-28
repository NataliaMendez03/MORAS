using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Context;
using Sistema_de_Gestion_Moras.Models;

namespace Sistema_de_Gestion_Moras.Repositories
{
    public interface ILevelsRepository
    {
        Task<List<Levels>> GetAll();
        Task<Levels> GetLevels(int idLevels);
        Task<Levels> CreateLevels(string nameLevel);
        Task<Levels> UpdateLevels(Levels Levels);
        Task<Levels> DeleteLevels(Levels Levels);
    }
    public class LevelsRepository : ILevelsRepository
    {
        private readonly berriesdbContext _db;
        public LevelsRepository(berriesdbContext db)
        {
            _db = db;
        }
        public async Task<Levels> CreateLevels(string nameLevel)
        {
            Levels newLevels = new Levels
            {
                NameLevel = nameLevel,
                StateDelete = false,
                ModifyDate = null
            };

            await _db.Levels.AddAsync(newLevels);
            _db.SaveChanges();

            return newLevels;
        }

        public async Task<Levels> DeleteLevels(Levels level)
        {
            _db.Levels.Attach(level); //Llamamos la actualizacion
            _db.Entry(level).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return level;
        }

        public async Task<List<Levels>> GetAll()
        {
            return await _db.Levels.ToListAsync();
        }

        public async Task<Levels> GetLevels(int idLevels)
        {
            return await _db.Levels.FirstOrDefaultAsync(u => u.IdLevel == idLevels);
        }

        public async Task<Levels> UpdateLevels(Levels Levels)
        {
            Levels LevelsUpdate = await _db.Levels.FindAsync(Levels.IdLevel);
            if (LevelsUpdate != null)
            {
                LevelsUpdate.NameLevel = Levels.NameLevel;

                await _db.SaveChangesAsync();
            }
            return LevelsUpdate;
        }
    }
}