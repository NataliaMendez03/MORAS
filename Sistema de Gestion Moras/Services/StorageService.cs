using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Repositories;
using System;

namespace Sistema_de_Gestion_Moras.Services
{
    public interface IStorageService
    {
        Task<List<Storage>> GetAll();
        Task<Storage> GetStorage(int idStorage);
        Task<Storage> CreateStorage(string storageName, int idHarvests, DateTime EntryDate, string Temperature);
        Task<Storage> UpdateStorage(int idStorage, string storageName, int? idHarvests = null, DateTime? EntryDate = null, string? Temperature = null);
        Task<Storage> DeleteStorage(int idStorage);
    }
    public class StorageService: IStorageService
    {
        public readonly IStorageRepository _storageRepository;
        public StorageService(IStorageRepository consultRepository)
        {
            _storageRepository = consultRepository;
        }

        public async Task<Storage> CreateStorage(string storageName, int idHarvests, DateTime EntryDate, string Temperature)
        {
            return await _storageRepository.CreateStorage(storageName, idHarvests, EntryDate, Temperature);
        }

        public async Task<Storage> DeleteStorage(int idStorage)
        {
            // comprobar si existe
            Storage consultToDelete = await _storageRepository.GetStorage(idStorage);
            if (consultToDelete == null)
            {
                throw new Exception($"This Storage with the Id {idStorage} don´t exist. ");
            }
            consultToDelete.StateDelete = true;
            consultToDelete.ModifyDate = DateTime.Now;
            return await _storageRepository.DeleteStorage(consultToDelete);
        }

        public async Task<List<Storage>> GetAll()
        {
            return await _storageRepository.GetAll();
        }

        public async Task<Storage> GetStorage(int idStorage)
        {
            return await _storageRepository.GetStorage(idStorage);
        }

        public async Task<Storage> UpdateStorage(int idStorage, string storageName, int? idHarvests = null, DateTime? EntryDate = null, string? Temperature = null)
        {
            Storage newStorage = await _storageRepository.GetStorage(idStorage);
            if (newStorage != null)
            {
                if (storageName != null)
                {
                    newStorage.StorageName = (string)storageName;
                }
                if (idHarvests != null)
                {
                    newStorage.IdHarvests = (int)idHarvests;
                }
                if (EntryDate != null)
                {
                    newStorage.EntryDate = (DateTime)EntryDate;
                }
                if (idHarvests != null)
                {
                    newStorage.Temperature = (string)Temperature;
                }
                return await _storageRepository.UpdateStorage(newStorage);
            }
            throw new NotImplementedException();
        }
    }
}
