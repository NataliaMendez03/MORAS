using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Repositories;

namespace Sistema_de_Gestion_Moras.Services
{
    public interface IPurchaseService
    {
        Task<List<Purchase>> GetAll();
        Task<Purchase> GetPurchase(int idPurchasen);
        Task<Purchase> CreatePurchase(int idProviders, int idPurchaseDetail);
        Task<Purchase> UpdatePurchase(int idPurchase, int? idProviders=null, int? idPurchaseDetail=null);
        Task<Purchase> DeletePurchase(int idPurchase);
    }
    public class PurchaseService : IPurchaseService
    {
        public readonly IPurchaseRepository _PurchaseRepository;
        public PurchaseService(IPurchaseRepository PurchasRepository)
        {
            _PurchaseRepository = PurchasRepository;
        }

        public async Task<Purchase> CreatePurchase(int idProviders, int idPurchaseDetail)
        {
            return await _PurchaseRepository.CreatePurchase(idProviders, idPurchaseDetail);
            throw new NotImplementedException();
        }

        public async Task<Purchase> DeletePurchase(int idPurchase)
        {
            Purchase PurchaseToDelete = await _PurchaseRepository.GetPurchase(idPurchase);
            if (PurchaseToDelete == null)
            {
                throw new Exception($"This Purchase with the Id {idPurchase} doesn´t exist. ");
            }
            PurchaseToDelete.StateDelete = true;
            PurchaseToDelete.ModifyDate = DateTime.Now;
            return await _PurchaseRepository.DeletePurchase(PurchaseToDelete);
            throw new NotImplementedException();
        }

        public async Task<List<Purchase>> GetAll()
        {
            return await _PurchaseRepository.GetAll();
            throw new NotImplementedException();
        }

        public async Task<Purchase> GetPurchase(int idPurchase)
        {
            return await _PurchaseRepository.GetPurchase(idPurchase);
            throw new NotImplementedException();
        }

        public async Task<Purchase> UpdatePurchase(int idPurchase, int? idProviders = null, int? idPurchaseDetail = null)
        {
            Purchase newPurchase = await _PurchaseRepository.GetPurchase(idPurchase);
            if (newPurchase != null)
            {

                if (idProviders != null)
                {
                    newPurchase.IdProviders = (int)idProviders;
                }
                
                if (idPurchaseDetail != null)
                {
                    newPurchase.IdPurchaseDetail = (int)idPurchaseDetail;
                }
                return await _PurchaseRepository.UpdatePurchase(newPurchase);
            }
            throw new NotImplementedException();
        }
    }
}