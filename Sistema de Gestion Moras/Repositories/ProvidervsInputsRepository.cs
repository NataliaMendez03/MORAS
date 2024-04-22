using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Context;
using Sistema_de_Gestion_Moras.Models;

namespace Sistema_de_Gestion_Moras.Repositories
{
    public interface IProvidervsInputsRepository
    {
        Task<List<ProvidervsInputs>> GetAll();
        Task<ProvidervsInputs> GetProvidervsInputs(int idProvsInp);
        Task<ProvidervsInputs> CreateProvidervsInputs(int idProviders, int idSupplies);
        Task<ProvidervsInputs> UpdateProvidervsInputs(ProvidervsInputs providervsInputs);
        Task<ProvidervsInputs> DeleteProvidervsInputs(ProvidervsInputs providervsInputs);
    }
    public class ProvidervsInputsRepository : IProvidervsInputsRepository
    {
        private readonly berriesdbContext _db;
        public ProvidervsInputsRepository(berriesdbContext db)
        {
            _db = db;
        }

        public async Task<ProvidervsInputs> CreateProvidervsInputs(int idProviders, int idSupplies)
        {
            Providers? providers = _db.Providers.FirstOrDefault(ut => ut.IdProviders == idProviders);
            Supplies? supplies = _db.Supplies.FirstOrDefault(ut => ut.IdSupplies == idSupplies);

            ProvidervsInputs newProvidervsInputs = new ProvidervsInputs
            {
                IdProviders = idProviders,
                IdSupplies = idSupplies,
                StateDelete = false,
                ModifyDate = null
            };

            await _db.ProvidervsInputs.AddAsync(newProvidervsInputs);
            _db.SaveChanges();
            return newProvidervsInputs;
            throw new NotImplementedException();
        }

        public async Task<ProvidervsInputs> DeleteProvidervsInputs(ProvidervsInputs providervsInputs)
        {
            _db.ProvidervsInputs.Attach(providervsInputs); //Llamamos la actualizacion
            _db.Entry(providervsInputs).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return providervsInputs;
            throw new NotImplementedException();
        }

        public async Task<List<ProvidervsInputs>> GetAll()
        {
            return await _db.ProvidervsInputs.ToListAsync();
            throw new NotImplementedException();
        }

        public async Task<ProvidervsInputs> GetProvidervsInputs(int idProvsInp)
        {
            return await _db.ProvidervsInputs.FirstOrDefaultAsync(u => u.IdProvsInp == idProvsInp);
            throw new NotImplementedException();
        }

        public async Task<ProvidervsInputs> UpdateProvidervsInputs(ProvidervsInputs providervsInputs)
        {
            ProvidervsInputs ProvidervsInputsUpdate = await _db.ProvidervsInputs.FindAsync(providervsInputs.IdProvsInp);
            if (ProvidervsInputsUpdate != null)
            {
                ProvidervsInputsUpdate.IdProviders = providervsInputs.IdProviders;
                ProvidervsInputsUpdate.IdSupplies = providervsInputs.IdSupplies;
                await _db.SaveChangesAsync();
            }

            return ProvidervsInputsUpdate;
            throw new NotImplementedException();
        }
    }
}