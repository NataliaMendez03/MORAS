using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Repositories;
using System.Net;

namespace Sistema_de_Gestion_Moras.Services
{
    public interface IEmployeesService
    {
        Task<List<Employees>> GetAll();
        Task<Employees> GetEmployees(int idEmployees);
        Task<Employees> CreateEmployees(int idPost, int idPerson);
        Task<Employees> UpdateEmployees(int idEmployees, int? idPost=null, int? idPerson=null);
        Task<Employees> DeleteEmployees(int idEmployees);
    }
    public class EmployeesService: IEmployeesService
    {
        public readonly IEmployeesRepository _employeesRepository;
        public EmployeesService(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        public async Task<Employees> CreateEmployees(int idPost, int idPerson)
        {
            return await _employeesRepository.CreateEmployees(idPost, idPerson);
        }

        public async Task<Employees> DeleteEmployees(int idEmployees)
        {
            // comprobar si existe
            Employees employeesToDelete = await _employeesRepository.GetEmployees(idEmployees);
            if (employeesToDelete == null)
            {
                throw new Exception($"This employees with the Id {idEmployees} don´t exist. ");
            }
            employeesToDelete.StateDelete = true;
            employeesToDelete.ModifyDate = DateTime.Now;
            return await _employeesRepository.DeleteEmployees(employeesToDelete);
        }

        public async Task<List<Employees>> GetAll()
        {
            return await _employeesRepository.GetAll();
        }

        public async Task<Employees> GetEmployees(int idEmployees)
        {
            return await _employeesRepository.GetEmployees(idEmployees);
        }

        public async Task<Employees> UpdateEmployees(int idEmployees, int? idPost = null, int? idPerson = null)
        {
            Employees newEmployees = await _employeesRepository.GetEmployees(idEmployees);
            if (newEmployees != null)
            {
                if (idPost != null)
                {
                    newEmployees.IdPost = (int)idPost;
                }
                if (idPerson != null)
                {
                    newEmployees.IdPerson = (int)idPerson;
                }
                return await _employeesRepository.UpdateEmployees(newEmployees);
            }
            throw new NotImplementedException();
        }
    }
}
