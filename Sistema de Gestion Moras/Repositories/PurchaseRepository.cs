using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Context;
using Sistema_de_Gestion_Moras.Models;

namespace Sistema_de_Gestion_Moras.Repositories
{
    public interface IPurchaseRepository
    {
        Task<List<Purchase>> GetAll();
        Task<Purchase> GetPurchase(int idPurchase);
        Task<Purchase> CreatePurchase(int idProviders, DateTime dateProviders, int idPurchaseDetail);
        Task<Purchase> UpdatePurchase(Purchase purchase );
        Task<Purchase> DeletePurchase(Purchase purchase);
    }
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly berriesdbContext _db;
        public PurchaseRepository(berriesdbContext db)
        {
            _db = db;
        }

        public async Task<Purchase> CreatePurchase(int idProviders, DateTime dateProviders, int idPurchaseDetail)
        {
            Providers? providers = _db.Providers.FirstOrDefault(ut => ut.IdProviders == idProviders);
            PurchaseDetail? purchaseDetail = _db.PurchaseDetail.FirstOrDefault(ut => ut.IdPurchaseDetail == idPurchaseDetail);

            Purchase newPurchase = new Purchase
            {
                IdProviders = idProviders,
                DateProviders = dateProviders,
                IdPurchaseDetail = idPurchaseDetail,
                StateDelete = false,
                CreatedDate = null
            };

            await _db.Purchase.AddAsync(newPurchase);
            _db.SaveChanges();
            return newPurchase;
            throw new NotImplementedException();
        }

        public async Task<Purchase> DeletePurchase(Purchase purchase)
        {
            _db.Purchase.Attach(purchase); //Llamamos la actualizacion
            _db.Entry(purchase).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return purchase;
            throw new NotImplementedException();
        }

        public async Task<List<Purchase>> GetAll()
        {
            return await _db.Purchase.ToListAsync();
            throw new NotImplementedException();
        }

        public async Task<Purchase> GetPurchase(int idPurchase)
        {
            return await _db.Purchase.FirstOrDefaultAsync(u => u.IdPurchase == idPurchase);
            throw new NotImplementedException();
        }

        public async Task<Purchase> UpdatePurchase(Purchase purchase)
        {
            Purchase PurchaseUpdate = await _db.Purchase.FindAsync(purchase.IdPurchase);
            if (PurchaseUpdate != null)
            {
                PurchaseUpdate.IdProviders = purchase.IdProviders;
                PurchaseUpdate.DateProviders = purchase.DateProviders;
                PurchaseUpdate.IdPurchaseDetail = purchase.IdPurchaseDetail;
                await _db.SaveChangesAsync();
            }

            return PurchaseUpdate;
            throw new NotImplementedException();
        }
    }
}