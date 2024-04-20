using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Context;
using Sistema_de_Gestion_Moras.Models;
using System;

namespace Sistema_de_Gestion_Moras.Repositories
{
    public interface IStorageRepository
    {
        Task<List<Storage>> GetAll();
        Task<Storage> GetStorage(int idStorage); 
        Task<Storage> CreateStorage(string storageName, int idHarvests, DateTime EntryDate, string Temperature);
        Task<Storage> UpdateStorage(Storage storage);
        Task<Storage> DeleteStorage(Storage storage);
    }
    public class StorageRepository : IStorageRepository
    {
        private readonly berriesdbContext _db;
        public StorageRepository(berriesdbContext db)
        {
            _db = db;
        }

        public async Task<Storage> CreateStorage(string storageName, int idHarvests, DateTime EntryDate, string Temperature)
        {
            Harvests? harvests = _db.Harvests.FirstOrDefault(ut => ut.IdHarvests == idHarvests);
            Storage newStorage = new Storage
            {
                StorageName = storageName,
                IdHarvests = idHarvests,
                EntryDate = EntryDate,
                Temperature = Temperature,
                StateDelete = false,
                CreatedDate = null
            };

            await _db.Storage.AddAsync(newStorage);
            _db.SaveChanges();

            return newStorage;
        }

        public async Task<Storage> DeleteStorage(Storage storage)
        {
            _db.Storage.Attach(storage); //Llamamos la actualizacion
            _db.Entry(storage).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return storage;
        }

        public async Task<List<Storage>> GetAll()
        {
            return await _db.Storage.ToListAsync();
        }

        public async Task<Storage> GetStorage(int idStorage)
        {
            return await _db.Storage.FirstOrDefaultAsync(u => u.IdStorage == idStorage);
        }

        public async Task<Storage> UpdateStorage(Storage storage)
        {
            Storage storageUpdate = await _db.Storage.FindAsync(storage.IdStorage);
            if (storageUpdate != null)
            {
                //?? ConsultUpdate.IdConsult = idConsult ;
                storageUpdate.StorageName = storage.StorageName;
                storageUpdate.IdHarvests = storage.IdHarvests;
                storageUpdate.EntryDate = storage.EntryDate;
                storageUpdate.Temperature = storage.Temperature;

                await _db.SaveChangesAsync();
            }

            return storageUpdate;
        }

    }
}
