using Sistema_de_Gestion_Moras.Models;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Context;
using Sistema_de_Gestion_Moras.Repositories;
namespace Sistema_de_Gestion_Moras.Services
{
    public interface IDispatchService
    {
        Task<List<Dispatch>> GetAll();
        Task<Dispatch> GetDispatch(int idDispatch); 
        Task<Dispatch> CreateDispatch(int idEmployees, int idSalesDetails, DateTime date, int idTracking);
        Task<Dispatch> UpdateDispatch(int idDispatch, int idEmployees, int idSalesDetails, DateTime date, int idTracking);
        Task<Dispatch> DeleteDispatch(int idDispatch);
    }
    public class DispatchService: IDispatchService
    {
        public readonly IDispatchRepository _dispatchRepository;
        public DispatchService(IDispatchRepository dispatchRepository)
        {
            _dispatchRepository = dispatchRepository;
        }

        public async Task<Dispatch> CreateDispatch(int idEmployees, int idSalesDetails, DateTime date, int idTracking)
        {
            return await _dispatchRepository.CreateDispatch(idEmployees, idSalesDetails, date, idTracking);
            throw new NotImplementedException();
        }

        public async Task<Dispatch> DeleteDispatch(int idDispatch)
        {
            Dispatch DispatchToDelete = await _dispatchRepository.GetDispatch(idDispatch);
            if (DispatchToDelete == null)
            {
                throw new Exception($"This dispatch with the Id {idDispatch} don´t exist. ");
            }
            DispatchToDelete.StateDelete = true;
            DispatchToDelete.CreatedDate = DateTime.Now;
            return await _dispatchRepository.DeleteDispatch(DispatchToDelete);
            throw new NotImplementedException();
        }

        public async Task<List<Dispatch>> GetAll()
        {
            return await _dispatchRepository.GetAll();
            throw new NotImplementedException();
        }

        public async Task<Dispatch> GetDispatch(int idDispatch)
        {
            return await _dispatchRepository.GetDispatch(idDispatch);
            throw new NotImplementedException();
        }

        public async Task<Dispatch> UpdateDispatch(int idDispatch, int idEmployees, int idSalesDetails, DateTime date, int idTracking)
        {
            Dispatch newDispatch = await _dispatchRepository.GetDispatch(idDispatch);
            if (newDispatch != null)
            {

                if (idEmployees != null)
                {
                    newDispatch.IdEmployees = (int)idEmployees;
                }
                if (idSalesDetails != null)
                {
                    newDispatch.IdSalesDetails = (int)idSalesDetails;
                }
                if (date != null)
                {
                    newDispatch.Date = (DateTime)date;
                }
                if (idTracking != null)
                {
                    newDispatch.IdTracking = (int)idTracking;
                }

                return await _dispatchRepository.UpdateDispatch(newDispatch);
            }
            throw new NotImplementedException();
        }
    }
}
