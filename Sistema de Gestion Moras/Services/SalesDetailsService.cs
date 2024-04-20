using Sistema_de_Gestion_Moras.Models;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Context;
using Sistema_de_Gestion_Moras.Repositories;
namespace Sistema_de_Gestion_Moras.Services
{
    public interface ISalesDetailsService
    {
        Task<List<SalesDetails>> GetAll();
        Task<SalesDetails> GetSalesDetails(int idSalesDetails); 
        Task<SalesDetails> CreateSalesDetails(string amount, string salePrice);
        Task<SalesDetails> UpdateSalesDetails(int idSalesDetails, string amount, string salePrice);
        Task<SalesDetails> DeleteSalesDetails(int idSalesDetails);
    }
public class SalesDetailsService: ISalesDetailsService
    {
        public readonly ISalesDetailsRepository _salesDetailsRepository;
        public SalesDetailsService(ISalesDetailsRepository salesDetailsRepository)
        {
            _salesDetailsRepository = salesDetailsRepository;
        }

        public async Task<SalesDetails> CreateSalesDetails(string amount, string salePrice)
        {
            return await _salesDetailsRepository.CreateSalesDetails(amount, salePrice);
            throw new NotImplementedException();
        }

        public async Task<SalesDetails> DeleteSalesDetails(int idSalesDetails)
        {
            SalesDetails SalesDetailsToDelete = await _salesDetailsRepository.GetSalesDetails(idSalesDetails);
            if (SalesDetailsToDelete == null)
            {
                throw new Exception($"This salesDetails with the Id {idSalesDetails} don´t exist. ");
            }
            SalesDetailsToDelete.StateDelete = true;
            SalesDetailsToDelete.CreatedDate = DateTime.Now;
            return await _salesDetailsRepository.DeleteSalesDetails(SalesDetailsToDelete);
            throw new NotImplementedException();
        }

        public async Task<List<SalesDetails>> GetAll()
        {
            return await _salesDetailsRepository.GetAll();
            throw new NotImplementedException();
        }

        public async Task<SalesDetails> GetSalesDetails(int idSalesDetails)
        {
            return await _salesDetailsRepository.GetSalesDetails(idSalesDetails);
            throw new NotImplementedException();
        }

        public async Task<SalesDetails> UpdateSalesDetails(int idSalesDetails, string amount, string salePrice)
        {
            SalesDetails newSalesDetails = await _salesDetailsRepository.GetSalesDetails(idSalesDetails);
            if (newSalesDetails != null)
            {

                if (amount != null)
                {
                    newSalesDetails.Amount = (string)amount;
                }
                if (salePrice != null)
                {
                    newSalesDetails.SalePrice = (string)salePrice;
                }

                return await _salesDetailsRepository.UpdateSalesDetails(newSalesDetails);
            }
            throw new NotImplementedException();
        }
    }
}
