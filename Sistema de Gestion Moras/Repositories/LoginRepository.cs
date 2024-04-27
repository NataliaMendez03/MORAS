using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Context;
using Sistema_de_Gestion_Moras.Models;
using System.Net;

namespace Sistema_de_Gestion_Moras.Repositories
{
    public interface ILoginRepository
    {
        Task<List<Login>> GetAll();
        Task<Login> GetLogin(int idLogin);
        Task<Login> CreateLogin(string username, string password, string email, DateTime registerDate);
        Task<Login> UpdateLogin(Login Login);
        Task<Login> DeleteLogin(Login Login);
    }
    public class LoginRepository : ILoginRepository
    {
        private readonly berriesdbContext _db;
        public LoginRepository(berriesdbContext db)
        {
            _db = db;
        }

        public async Task<Login> CreateLogin(string username, string password, string email, DateTime registerDate)
        {
            Login newLogin = new Login
            {
                UserName = username,
                Password = password,
                Email = email,
                RegisterDate = registerDate,
                StateDelete = false,
                ModifyDate = null
            };

            await _db.Login.AddAsync(newLogin);
            _db.SaveChanges();

            return newLogin;
        }

        public async Task<Login> DeleteLogin(Login Login)
        {
            _db.Login.Attach(Login); //Llamamos la actualizacion
            _db.Entry(Login).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return Login;
        }

        public async Task<List<Login>> GetAll()
        {
            return await _db.Login.ToListAsync();
        }

        public async Task<Login> GetLogin(int idLogin)
        {
            return await _db.Login.FirstOrDefaultAsync(u => u.IdLogin == idLogin);
        }

        public async Task<Login> UpdateLogin(Login Login)
        {
            Login LoginUpdate = await _db.Login.FindAsync(Login.IdLogin);
            if (LoginUpdate != null)
            {
                LoginUpdate.UserName = Login.UserName;
                LoginUpdate.Password = Login.Password;
                LoginUpdate.Email = Login.Email;
                LoginUpdate.RegisterDate = Login.RegisterDate;

                await _db.SaveChangesAsync();
            }

            return LoginUpdate;
        }
    }
}
