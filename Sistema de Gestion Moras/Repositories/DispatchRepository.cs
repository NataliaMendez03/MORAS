
using Sistema_de_Gestion_Moras.Models;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Context;
namespace Sistema_de_Gestion_Moras.Repositories
{
    public interface IDispatchRepository
    {
        Task<List<Dispatch>> GetAll();
        Task<Dispatch> GetDispatch(int idDispatch); 
        Task<Dispatch> CreateDispatch(int idEmployees, int idSalesDetails, DateTime date, int idTracking);
        Task<Dispatch> UpdateDispatch(Dispatch dispatch);
        Task<Dispatch> DeleteDispatch(Dispatch dispatch);
    }
    public class DispatchRepository : IDispatchRepository
    {
        private readonly berriesdbContext _db;
        public DispatchRepository(berriesdbContext db)
        {
            _db = db;
        }

        public async Task<Dispatch> CreateDispatch(int idEmployees, int idSalesDetails, DateTime date, int idTracking)
        {
            Employees? employees = _db.Employees.FirstOrDefault(ut => ut.IdEmployees == idEmployees);
            SalesDetails? salesDetails = _db.SalesDetails.FirstOrDefault(ut => ut.IdSalesDetails == idSalesDetails);
            Tracking? tracking = _db.Tracking.FirstOrDefault(ut => ut.IdTracking == idTracking);

            Dispatch newDispatch = new Dispatch
            {
                IdEmployees = idEmployees,
                IdSalesDetails = idSalesDetails,
                Date = date,
                IdTracking = idTracking,
                StateDelete = false,
                ModifyDate = null
            };

            await _db.Dispatch.AddAsync(newDispatch);
            _db.SaveChanges();
            return newDispatch;
            throw new NotImplementedException();
        }

        public async Task<Dispatch> DeleteDispatch(Dispatch dispatch)
        {
            _db.Dispatch.Attach(dispatch); //Llamamos la actualizacion
            _db.Entry(dispatch).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return dispatch;
            throw new NotImplementedException();
        }

        public async Task<List<Dispatch>> GetAll()
        {
            return await _db.Dispatch.ToListAsync();
            throw new NotImplementedException();
        }

        public async Task<Dispatch> GetDispatch(int idDispatch)
        {
            return await _db.Dispatch.FirstOrDefaultAsync(u => u.IdDispatch == idDispatch);
            throw new NotImplementedException();
        }

        public async Task<Dispatch> UpdateDispatch(Dispatch dispatch)
        {
            Dispatch ConsultUpdate = await _db.Dispatch.FindAsync(dispatch.IdDispatch);
            if (ConsultUpdate != null)
            {
                ConsultUpdate.IdEmployees = dispatch.IdEmployees;
                ConsultUpdate.Date = dispatch.Date;
                ConsultUpdate.IdTracking = dispatch.IdTracking;
                ConsultUpdate.IdSalesDetails = dispatch.IdSalesDetails;

                await _db.SaveChangesAsync();
            }

            return ConsultUpdate;
            throw new NotImplementedException();
        }
    }
}
