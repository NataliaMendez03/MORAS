using Sistema_de_Gestion_Moras.Models;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Context;
namespace Sistema_de_Gestion_Moras.Repositories
{
    public interface ISalesDetailsRepository
    {
        Task<List<SalesDetails>> GetAll();
        Task<SalesDetails> GetSalesDetails(int idSalesDetails); 
        Task<SalesDetails> CreateSalesDetails(string amount, string salePrice);
        Task<SalesDetails> UpdateSalesDetails(SalesDetails salesDetails);
        Task<SalesDetails> DeleteSalesDetails(SalesDetails salesDetails);
    }
    public class SalesDetailsRepository : ISalesDetailsRepository
    {
        private readonly berriesdbContext _db;
        public SalesDetailsRepository(berriesdbContext db)
        {
            _db = db;
        }

        public async Task<SalesDetails> CreateSalesDetails(string amount, string salePrice)
        {
            SalesDetails newSalesDetails = new SalesDetails
            {

                Amount = amount,
                SalePrice = salePrice,
                StateDelete = false,
                CreatedDate = null
            };

            await _db.SalesDetails.AddAsync(newSalesDetails);
            _db.SaveChanges();
            return newSalesDetails;
            throw new NotImplementedException();
        }

        public async Task<SalesDetails> DeleteSalesDetails(SalesDetails salesDetails)
        {
            _db.SalesDetails.Attach(salesDetails); //Llamamos la actualizacion
            _db.Entry(salesDetails).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return salesDetails;
            throw new NotImplementedException();
        }

        public async Task<List<SalesDetails>> GetAll()
        {
            return await _db.SalesDetails.ToListAsync();
            throw new NotImplementedException();
        }

        public async Task<SalesDetails> GetSalesDetails(int idSalesDetails)
        {
            return await _db.SalesDetails.FirstOrDefaultAsync(u => u.IdSalesDetails == idSalesDetails);

            throw new NotImplementedException();
        }

        public async Task<SalesDetails> UpdateSalesDetails(SalesDetails salesDetails)
        {
            SalesDetails ConsultUpdate = await _db.SalesDetails.FindAsync(salesDetails.IdSalesDetails);
            if (ConsultUpdate != null)
            {
                ConsultUpdate.Amount = salesDetails.Amount;
                ConsultUpdate.SalePrice = salesDetails.SalePrice;

                await _db.SaveChangesAsync();
            }

            return ConsultUpdate;
            throw new NotImplementedException();
        }
    }
}
