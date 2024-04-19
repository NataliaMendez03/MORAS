using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Context;
using Sistema_de_Gestion_Moras.Models;
using System.Data.SqlTypes;
using System.Net;

namespace Sistema_de_Gestion_Moras.Repositories
{
    public interface IPurchaseDetailRepository
    {
        Task<List<PurchaseDetail>> GetAll();
        Task<PurchaseDetail> GetPurchaseDetail(int idPurchaseDetail);
        Task<PurchaseDetail> CreatePurchaseDetail(int idSupplies, string quantity, SqlMoney purchasePrice, string notes);
        Task<PurchaseDetail> UpdatePurchaseDetail(PurchaseDetail purchaseDetail);
        Task<PurchaseDetail> DeletePurchaseDetail(PurchaseDetail purchaseDetail);
    }
    public class PurchaseDetailRepository: IPurchaseDetailRepository
    {
        private readonly berriesdbContext _db;
        public PurchaseDetailRepository(berriesdbContext db)
        {
            _db = db;
        }

        public async Task<PurchaseDetail> CreatePurchaseDetail(int idSupplies, string quantity, SqlMoney purchasePrice, string notes)
        {
            PurchaseDetail newPurchaseDetail = new PurchaseDetail
            {
                IdSupplies = idSupplies,
                Quantity = quantity,
                PurchasePrice = purchasePrice,
                Notes = notes,
                StateDelete = false,
                CreatedDate = null
            };

            await _db.PurchaseDetail.AddAsync(newPurchaseDetail);
            _db.SaveChanges();

            return newPurchaseDetail;
        }

        public async Task<PurchaseDetail> DeletePurchaseDetail(PurchaseDetail purchaseDetail)
        {
            _db.PurchaseDetail.Attach(purchaseDetail); //Llamamos la actualizacion
            _db.Entry(purchaseDetail).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return purchaseDetail;
        }

        public async Task<List<PurchaseDetail>> GetAll()
        {
            return await _db.PurchaseDetail.ToListAsync();
        }

        public async Task<PurchaseDetail> GetPurchaseDetail(int idPurchaseDetail)
        {
            return await _db.PurchaseDetail.FirstOrDefaultAsync(u => u.IdPurchaseDetail == idPurchaseDetail);
        }

        public async Task<PurchaseDetail> UpdatePurchaseDetail(PurchaseDetail purchaseDetail)
        {
            PurchaseDetail PurchaseDetailUpdate = await _db.PurchaseDetail.FindAsync(purchaseDetail.IdPurchaseDetail);
            if (PurchaseDetailUpdate != null)
            {
                //?? ConsultUpdate.IdConsult = idConsult;
                PurchaseDetailUpdate.IdSupplies = purchaseDetail.IdSupplies;
                PurchaseDetailUpdate.Quantity = purchaseDetail.Quantity;
                PurchaseDetailUpdate.PurchasePrice = purchaseDetail.PurchasePrice;
                PurchaseDetailUpdate.Notes = purchaseDetail.Notes;

                await _db.SaveChangesAsync();
            }

            return PurchaseDetailUpdate;
        }
    }
}
