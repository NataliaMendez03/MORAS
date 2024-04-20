using Sistema_de_Gestion_Moras.Models;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Context;
using Sistema_de_Gestion_Moras.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Sistema_de_Gestion_Moras.Services
{
    public interface ITrackingService
    {
        Task<List<Tracking>> GetAll();
        Task<Tracking> GetTracking(int IdTracking);
        Task<Tracking> CreateTracking(DateTime datetracking, int idState);
        Task<Tracking> UpdateTracking(int IdTracking, DateTime? datetracking = null, int? idState = null);
        Task<Tracking> DeleteTracking(int IdTracking);
    }
    public class TrackingService : ITrackingService
    {
        public readonly ITrackingRepository _trackingService;
        public TrackingService(ITrackingRepository trackingRepository)
        {
            _trackingService = trackingRepository;
        }

        public async Task<Tracking> CreateTracking(DateTime datetracking, int idState)
        {
            return await _trackingService.CreateTracking(datetracking, idState);
            throw new NotImplementedException();
        }

        public async Task<Tracking> DeleteTracking(int IdTracking)
        {
            Tracking TrackingToDelete = await _trackingService.GetTracking(IdTracking);
            if (TrackingToDelete == null)
            {
                throw new Exception($"This tracking with the Id {IdTracking} don´t exist. ");
            }
            TrackingToDelete.StateDelete = true;
            TrackingToDelete.CreatedDate = DateTime.Now; 
            return await _trackingService.DeleteTracking(TrackingToDelete);
            throw new NotImplementedException();
        }

        public async Task<List<Tracking>> GetAll()
        {
            return await _trackingService.GetAll();
            throw new NotImplementedException();
        }

        public async Task<Tracking> GetTracking(int IdTracking)
        {
            return await _trackingService.GetTracking(IdTracking);
            throw new NotImplementedException();
        }

        public async Task<Tracking> UpdateTracking(int IdTracking, DateTime? datetracking = null, int? idState = null)
        {
            Tracking newTracking = await _trackingService.GetTracking(IdTracking);
            if (newTracking != null)
            {

                if (datetracking != null)
                {
                    newTracking.DateTracking = (DateTime)datetracking;
                }
                if (idState != null)
                {
                    newTracking.IdState = (int)idState;
                }
   
                return await _trackingService.UpdateTracking(newTracking);
            }
            throw new NotImplementedException();
        }
    }
}
