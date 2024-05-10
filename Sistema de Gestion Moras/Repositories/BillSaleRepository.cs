using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Context;
using Sistema_de_Gestion_Moras.Models;

namespace Sistema_de_Gestion_Moras.Repositories
{
    public interface IBillSaleRepository
    {
        Task<List<BillSale>> GetAll();
        Task<BillSale> GetBillSale(int idBillSale);
        Task<BillSale> CreateBillSale(int idClient, int idSalesDetails, string notes);
        Task<BillSale> UpdateBillSale(BillSale billSale);
        Task<BillSale> DeleteBillSale(BillSale billSale);
    }
    public class BillSaleRepository : IBillSaleRepository
    {
        private readonly berriesdbContext _db;
        public BillSaleRepository(berriesdbContext db)
        {
            _db = db;
        }

        public async Task<BillSale> CreateBillSale(int idClient, int idSalesDetails, string notes)
        {
            Client? client = _db.Client.FirstOrDefault(ut => ut.IdClient == idClient);
            SalesDetails? salesDetails = _db.SalesDetails.FirstOrDefault(ut => ut.IdSalesDetails == idSalesDetails);

            BillSale newBillSale = new BillSale
            {
                IdClient = idClient,
                DateSale = DateTime.Now,
                IdSalesDetails = idSalesDetails,
                Notes = notes,
                StateDelete = false,
                ModifyDate = null
            };

            await _db.BillSale.AddAsync(newBillSale);
            _db.SaveChanges();
            return newBillSale;
            throw new NotImplementedException();
        }

        public async Task<BillSale> DeleteBillSale(BillSale billSale)
        {
            _db.BillSale.Attach(billSale); //Llamamos la actualizacion
            _db.Entry(billSale).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return billSale;
            throw new NotImplementedException();
        }

        public async Task<List<BillSale>> GetAll()
        {
            return await _db.BillSale.ToListAsync();
            throw new NotImplementedException();
        }

        public async Task<BillSale> GetBillSale(int idBillSale)
        {
            return await _db.BillSale.FirstOrDefaultAsync(u => u.IdBillSale == idBillSale);
            throw new NotImplementedException();
        }

        public async Task<BillSale> UpdateBillSale(BillSale billSale)
        {
            BillSale BillSaleUpdate = await _db.BillSale.FindAsync(billSale.IdBillSale);
            if (BillSaleUpdate != null)
            {
                BillSaleUpdate.IdClient = billSale.IdClient;
                BillSaleUpdate.IdSalesDetails = billSale.IdSalesDetails;
                BillSaleUpdate.Notes = billSale.Notes;
                await _db.SaveChangesAsync();
            }

            return BillSaleUpdate;
            throw new NotImplementedException();
        }
    }
}