using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Context;
using Sistema_de_Gestion_Moras.Models;
using System.Net;

namespace Sistema_de_Gestion_Moras.Repositories
{
    public interface IEmployeesRepository
    {
        Task<List<Employees>> GetAll();
        Task<Employees> GetEmployees(int idEmployees);
        Task<Employees> CreateEmployees(int idPost, int idPerson);
        Task<Employees> UpdateEmployees(Employees employees);
        Task<Employees> DeleteEmployees(Employees employees);
    }
    public class EmployeesRepository: IEmployeesRepository
    {
        private readonly berriesdbContext _db;
        public EmployeesRepository(berriesdbContext db)
        {
            _db = db;
        }

        public async Task<Employees> CreateEmployees(int idPost, int idPerson)
        {
            Post? post = _db.Post.FirstOrDefault(ut => ut.IdPost == idPost);
            Person? person = _db.Person.FirstOrDefault(ut => ut.IdPerson == idPerson);
            Employees newEmployees = new Employees
            {
                IdPost = idPost,
                IdPerson = idPerson,
                StateDelete = false,
                CreatedDate = null
            };

            await _db.Employees.AddAsync(newEmployees);
            _db.SaveChanges();

            return newEmployees;
        }

        public async Task<Employees> DeleteEmployees(Employees employees)
        {
            _db.Employees.Attach(employees); //Llamamos la actualizacion
            _db.Entry(employees).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return employees;
        }

        public async Task<List<Employees>> GetAll()
        {
            return await _db.Employees.ToListAsync();
        }

        public async Task<Employees> GetEmployees(int idEmployees)
        {
            return await _db.Employees.FirstOrDefaultAsync(u => u.IdEmployees == idEmployees);
        }

        public async Task<Employees> UpdateEmployees(Employees employees)
        {
            Employees EmployeesUpdate = await _db.Employees.FindAsync(employees.IdEmployees);
            if (EmployeesUpdate != null)
            {
                //?? ConsultUpdate.IdConsult = idConsult;
                EmployeesUpdate.IdPost = employees.IdPost;
                EmployeesUpdate.IdPerson = employees.IdPerson;

                await _db.SaveChangesAsync();
            }

            return EmployeesUpdate;
        }
    }
}
