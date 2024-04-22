using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Context;
using Sistema_de_Gestion_Moras.Models;

namespace Sistema_de_Gestion_Moras.Repositories
{
    public interface IProvidersRepository
    {
        Task<List<Providers>> GetAll();
        Task<Providers> GetProviders(int idProviders);
        Task<Providers> CreateProviders(int idPerson);
        Task<Providers> UpdateProviders(Providers providers);
        Task<Providers> DeleteProviders(Providers providers);
    }
    public class ProvidersRepository : IProvidersRepository
    {
        private readonly berriesdbContext _db;
        public ProvidersRepository(berriesdbContext db)
        {
            _db = db;
        }
        public async Task<Providers> CreateProviders(int idPerson)
        {
            Person? user = _db.Person.FirstOrDefault(ut => ut.IdPerson == idPerson);
            Providers newProviders = new Providers
            {
                IdPerson = idPerson,
                StateDelete = false,
                ModifyDate = null
            };

            await _db.Providers.AddAsync(newProviders);
            _db.SaveChanges();

            return newProviders;
        }

        public async Task<Providers> DeleteProviders(Providers providers)
        {
            _db.Providers.Attach(providers); //Llamamos la actualizacion
            _db.Entry(providers).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return providers;
        }

        public async Task<List<Providers>> GetAll()
        {
            return await _db.Providers.ToListAsync();
        }

        public async Task<Providers> GetProviders(int idProviders)
        {
            return await _db.Providers.FirstOrDefaultAsync(u => u.IdProviders == idProviders);
        }

        public async Task<Providers> UpdateProviders(Providers providers)
        {
            Providers ProvidersUpdate = await _db.Providers.FindAsync(providers.IdProviders);
            if (ProvidersUpdate != null)
            {
                ProvidersUpdate.IdPerson = providers.IdPerson;

                await _db.SaveChangesAsync();
            }
            return ProvidersUpdate;
        }
    }
}