
using Sistema_de_Gestion_Moras.Models;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Context;
namespace Sistema_de_Gestion_Moras.Repositories
{
    public interface ISuppliesRepository
    {
        Task<List<Supplies>> GetAll();
        Task<Supplies> GetSupplies(int idSupplies); 
        Task<Supplies> CreateSupplies(string nameSupplies);
        Task<Supplies> UpdateSupplies(Supplies supplies);
        Task<Supplies> DeleteSupplies(Supplies supplies);
    }
    public class SuppliesRepository : ISuppliesRepository
    {
        private readonly berriesdbContext _db;
        public SuppliesRepository(berriesdbContext db)
        {
            _db = db;
        }

        public async Task<Supplies> CreateSupplies(string nameSupplies)
        {
            Supplies newSupplies = new Supplies
            {
                NameSupplies = nameSupplies,
                StateDelete = false,
                ModifyDate = null
            };

            await _db.Supplies.AddAsync(newSupplies);
            _db.SaveChanges();
            return newSupplies;
            throw new NotImplementedException();
        }

        public async Task<Supplies> DeleteSupplies(Supplies supplies)
        {
            _db.Supplies.Attach(supplies); //Llamamos la actualizacion
            _db.Entry(supplies).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return supplies;
            throw new NotImplementedException();
        }

        public async Task<List<Supplies>> GetAll()
        {
            return await _db.Supplies.ToListAsync();
            throw new NotImplementedException();
        }

        public async Task<Supplies> GetSupplies(int idSupplies)
        {
            return await _db.Supplies.FirstOrDefaultAsync(u => u.IdSupplies == idSupplies);
            throw new NotImplementedException();
        }

        public async Task<Supplies> UpdateSupplies(Supplies supplies)
        {
            Supplies ConsultUpdate = await _db.Supplies.FindAsync(supplies.IdSupplies);
            if (ConsultUpdate != null)
            {
                ConsultUpdate.NameSupplies = supplies.NameSupplies;

                await _db.SaveChangesAsync();
            }

            return ConsultUpdate;
            throw new NotImplementedException();
        }
    }
}
