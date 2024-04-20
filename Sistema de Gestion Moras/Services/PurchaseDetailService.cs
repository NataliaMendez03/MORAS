using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Repositories;
using System.Data.SqlTypes;
using System.Net;

namespace Sistema_de_Gestion_Moras.Services
{
    public interface IPurchaseDetailService
    {
        Task<List<PurchaseDetail>> GetAll();
        Task<PurchaseDetail> GetPurchaseDetail(int idPurchaseDetail);
        Task<PurchaseDetail> CreatePurchaseDetail(int idSupplies, int quantity, string purchasePrice, string notes);
        Task<PurchaseDetail> UpdatePurchaseDetail(int idPurchaseDetail, int? idSupplies=null, int? quantity=null, string? purchasePrice=null, string? notes=null);
        Task<PurchaseDetail> DeletePurchaseDetail(int idPurchaseDetail);
    }
    public class PurchaseDetailService: IPurchaseDetailService
    {
        public readonly IPurchaseDetailRepository _purchaseDetailRepository;
        public PurchaseDetailService(IPurchaseDetailRepository purchaseDetailRepository)
        {
            _purchaseDetailRepository = purchaseDetailRepository;
        }

        public async Task<PurchaseDetail> CreatePurchaseDetail(int idSupplies, int quantity, string purchasePrice, string notes)
        {
            return await _purchaseDetailRepository.CreatePurchaseDetail(idSupplies, quantity, purchasePrice, notes);
        }

        public async Task<PurchaseDetail> DeletePurchaseDetail(int idPurchaseDetail)
        {
            // comprobar si existe
            PurchaseDetail purchaseDetailsToDelete = await _purchaseDetailRepository.GetPurchaseDetail(idPurchaseDetail);
            if (purchaseDetailsToDelete == null)
            {
                throw new Exception($"This PurchaseDetail with the Id {idPurchaseDetail} don´t exist. ");
            }
            purchaseDetailsToDelete.StateDelete = true;
            purchaseDetailsToDelete.CreatedDate = DateTime.Now;
            return await _purchaseDetailRepository.DeletePurchaseDetail(purchaseDetailsToDelete);
        }

        public async Task<List<PurchaseDetail>> GetAll()
        {
            return await _purchaseDetailRepository.GetAll();
        }

        public async Task<PurchaseDetail> GetPurchaseDetail(int idPurchaseDetail)
        {
            return await _purchaseDetailRepository.GetPurchaseDetail(idPurchaseDetail);
        }

        public async Task<PurchaseDetail> UpdatePurchaseDetail(int idPurchaseDetail, int? idSupplies = null, int? quantity = null, string? purchasePrice = null, string? notes = null)
        {
            PurchaseDetail newPurchaseDetail = await _purchaseDetailRepository.GetPurchaseDetail(idPurchaseDetail);
            if (newPurchaseDetail != null)
            {
                if (idSupplies != null)
                {
                    newPurchaseDetail.IdSupplies = (int)idSupplies;
                }
                if (quantity != null)
                {
                    newPurchaseDetail.Quantity = (int)quantity;
                }
                if (purchasePrice != null)
                {
                    newPurchaseDetail.PurchasePrice = (string)purchasePrice;
                }
                if (notes != null)
                {
                    newPurchaseDetail.Notes = (string)notes;
                }
                return await _purchaseDetailRepository.UpdatePurchaseDetail(newPurchaseDetail);
            }
            throw new NotImplementedException();
        }
    }
}
