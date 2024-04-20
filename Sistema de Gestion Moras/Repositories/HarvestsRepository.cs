
using Sistema_de_Gestion_Moras.Models;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Context;
namespace Sistema_de_Gestion_Moras.Repositories
{
    public interface IHarvestsRepository
    {
        Task<List<Harvests>> GetAll();
        Task<Harvests> GetHarvests(int idHarvests); 
        Task<Harvests> CreateHarvests(DateTime harvestDate, string harvestAmount, int idemployees, int idQuality);
        Task<Harvests> UpdateHarvests(Harvests harvests);
        Task<Harvests> DeleteHarvests(Harvests harvests);
    }
    public class HarvestsRepository : IHarvestsRepository
    {
        private readonly berriesdbContext _db;
        public HarvestsRepository(berriesdbContext db)
        {
            _db = db;
        }

        public async Task<Harvests> CreateHarvests(DateTime harvestDate, string harvestAmount, int idemployees, int idQuality)
        {
            Employees? employees = _db.Employees.FirstOrDefault(ut => ut.IdEmployees == idemployees);
            Quality? quality = _db.Quality.FirstOrDefault(ut => ut.IdQuality == idQuality);

            Harvests newHarvests = new Harvests
            {
                HarvestDate = harvestDate,
                HarvestAmount = harvestAmount,
                Idemployees = idemployees,
                IdQuality = idQuality,
                StateDelete = false,
                CreatedDate = null
            };

            await _db.Harvests.AddAsync(newHarvests);
            _db.SaveChanges();
            return newHarvests;
            throw new NotImplementedException();
        }

        public async Task<Harvests> DeleteHarvests(Harvests harvests)
        {
            _db.Harvests.Attach(harvests); //Llamamos la actualizacion
            _db.Entry(harvests).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return harvests;
            throw new NotImplementedException();
        }

        public async Task<List<Harvests>> GetAll()
        {
            return await _db.Harvests.ToListAsync();
            throw new NotImplementedException();
        }

        public async Task<Harvests> GetHarvests(int idHarvests)
        {
            return await _db.Harvests.FirstOrDefaultAsync(u => u.IdHarvests == idHarvests);
            throw new NotImplementedException();
        }

        public async Task<Harvests> UpdateHarvests(Harvests harvests)
        {
            Harvests ConsultUpdate = await _db.Harvests.FindAsync(harvests.IdHarvests);
            if (ConsultUpdate != null)
            {
                ConsultUpdate.HarvestDate = harvests.HarvestDate;
                ConsultUpdate.HarvestAmount = harvests.HarvestAmount;
                ConsultUpdate.Idemployees = harvests.Idemployees;
                ConsultUpdate.IdQuality = harvests.IdQuality;

                await _db.SaveChangesAsync();
            }

            return ConsultUpdate;
            throw new NotImplementedException();
        }
    }
}
