using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Repositories;

namespace Sistema_de_Gestion_Moras.Services
{
    public interface IBillSaleService
    {
        Task<List<BillSale>> GetAll();
        Task<BillSale> GetBillSale(int idBillSale);
        Task<BillSale> CreateBillSale(int idClient, DateTime dateSale, int idSalesDetails, string notes);
        Task<BillSale> UpdateBillSale(int idBillSale, int? idClient=null, DateTime? dateSale=null, int? idSalesDetails = null, string? notes = null);
        Task<BillSale> DeleteBillSale(int idBillSale);
    }
    public class BillSaleService : IBillSaleService
    {
        public readonly IBillSaleRepository _BillSaleRepository;
        public BillSaleService(IBillSaleRepository BillSaleRepository)
        {
            _BillSaleRepository = BillSaleRepository;
        }

        public async Task<BillSale> CreateBillSale(int idClient, DateTime dateSale, int idSalesDetails, string notes)
        {
            return await _BillSaleRepository.CreateBillSale(idClient, dateSale, idSalesDetails, notes);
            throw new NotImplementedException();
        }

        public async Task<BillSale> DeleteBillSale(int idBillSale)
        {
            BillSale BillSaleToDelete = await _BillSaleRepository.GetBillSale(idBillSale);
            if (BillSaleToDelete == null)
            {
                throw new Exception($"This BillSale with the Id {idBillSale} doesn´t exist. ");
            }
            BillSaleToDelete.StateDelete = true;
            BillSaleToDelete.CreatedDate = DateTime.Now;
            return await _BillSaleRepository.DeleteBillSale(BillSaleToDelete);
            throw new NotImplementedException();
        }

        public async Task<List<BillSale>> GetAll()
        {
            return await _BillSaleRepository.GetAll();
            throw new NotImplementedException();
        }

        public async Task<BillSale> GetBillSale(int idBillSale)
        {
            return await _BillSaleRepository.GetBillSale(idBillSale);
            throw new NotImplementedException();
        }

        public async Task<BillSale> UpdateBillSale(int idBillSale, int? idClient = null, DateTime? dateSale = null, int? idSalesDetails = null, string? notes = null)
        {
            BillSale newBillSale = await _BillSaleRepository.GetBillSale(idBillSale);
            if (newBillSale != null)
            {

                if (idClient != null)
                {
                    newBillSale.IdClient = (int)idClient;
                }
                if (dateSale != null)
                {
                    newBillSale.DateSale = (DateTime)dateSale;
                }
                if (idSalesDetails != null)
                {
                    newBillSale.IdSalesDetails = (int)idSalesDetails;
                }
                if (notes != null)
                {
                    newBillSale.Notes = (string)notes;
                }
                return await _BillSaleRepository.UpdateBillSale(newBillSale);
            }
            throw new NotImplementedException();
        }
    }
}