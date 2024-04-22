using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Context;
using Sistema_de_Gestion_Moras.Models;

namespace Sistema_de_Gestion_Moras.Repositories
{
    public interface IQualityRepository
    {
        Task<List<Quality>> GetAll();
        Task<Quality> GetQuality(int idQuality);
        Task<Quality> CreateQuality(string nQuality, string quantity);
        Task<Quality> UpdateQuality(Quality quality);
        Task<Quality> DeleteQuality(Quality quality);
    }
    public class QualityRepository : IQualityRepository
    {
        private readonly berriesdbContext _db;
        public QualityRepository(berriesdbContext db)
        {
            _db = db;
        }
        public async Task<Quality> CreateQuality(string nQuality, string quantity)
        {
            Quality newQuality = new Quality
            {
                NQuality = nQuality,
                Quantity = quantity,
                StateDelete = false,
                ModifyDate = null
            };

            await _db.Quality.AddAsync(newQuality);
            _db.SaveChanges();

            return newQuality;
        }

        public async Task<Quality> DeleteQuality(Quality quality)
        {
            _db.Quality.Attach(quality); //Llamamos la actualizacion
            _db.Entry(quality).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return quality;
        }

        public async Task<List<Quality>> GetAll()
        {
            return await _db.Quality.ToListAsync();
        }

        public async Task<Quality> GetQuality(int idQuality)
        {
            return await _db.Quality.FirstOrDefaultAsync(u => u.IdQuality == idQuality);
        }

        public async Task<Quality> UpdateQuality(Quality quality)
        {
            Quality QualityUpdate = await _db.Quality.FindAsync(quality.IdQuality);
            if (QualityUpdate != null)
            {
                QualityUpdate.NQuality = quality.NQuality;
                QualityUpdate.Quantity = quality.Quantity;

                await _db.SaveChangesAsync();
            }
            return QualityUpdate;
        }
    }
}