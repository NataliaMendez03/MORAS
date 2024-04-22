using Sistema_de_Gestion_Moras.Models;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Context;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Sistema_de_Gestion_Moras.Repositories
{
    public interface ITrackingRepository
    {
        Task<List<Tracking>> GetAll(); 
        Task<Tracking> GetTracking(int IdTracking);
        Task<Tracking> CreateTracking(DateTime datetracking, int idState);
        Task<Tracking> UpdateTracking(Tracking tracking);
        Task<Tracking> DeleteTracking(Tracking tracking);
    }


        public class TrackingRepository : ITrackingRepository
    {
        private readonly berriesdbContext _db;
        public TrackingRepository( berriesdbContext db)
        {
            _db = db;
        }

        public async Task<Tracking> CreateTracking(DateTime datetracking, int idState)
        {
            State? state = _db.State.FirstOrDefault(ut => ut.IdState == idState);

            Tracking newTracking = new Tracking
            {

                DateTracking = datetracking,
                IdState = idState,
                StateDelete = false,
                ModifyDate = null
            };

            await _db.Tracking.AddAsync(newTracking);
            _db.SaveChanges();
            return newTracking;
            throw new NotImplementedException();
        }

        public async Task<Tracking> DeleteTracking(Tracking tracking)
        {
            _db.Tracking.Attach(tracking); //Llamamos la actualizacion
            _db.Entry(tracking).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return tracking;
            throw new NotImplementedException();
        }

        public async Task<List<Tracking>> GetAll()
        {
            return await _db.Tracking.ToListAsync();
            throw new NotImplementedException();
        }

        public async Task<Tracking> GetTracking(int IdTracking)
        {
            return await _db.Tracking.FirstOrDefaultAsync(u => u.IdTracking == IdTracking);
            throw new NotImplementedException();
        }

        public async Task<Tracking> UpdateTracking(Tracking tracking)
        {
            Tracking ConsultUpdate = await _db.Tracking.FindAsync(tracking.IdTracking);
            if (ConsultUpdate != null)
            {
      
                ConsultUpdate.DateTracking = tracking.DateTracking;
                ConsultUpdate.IdState = tracking.IdState;

                await _db.SaveChangesAsync();
            }

            return ConsultUpdate;
            throw new NotImplementedException();
        }
    }
}
