using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Context;
using Sistema_de_Gestion_Moras.Migrations;
using Sistema_de_Gestion_Moras.Models;

namespace Sistema_de_Gestion_Moras.Repositories
{
    public interface ILoginRepository
    {
        Task<List<Login>> GetAll();
        Task<Login> GetLogin(int idLogin);
        Task<int?> GetIdByUsername(string username);
        Task<Login> CreateLogin(string userName, string password, string email);
        Task<Login> UpdateLogin(Login login);
        Task<Login> DeleteLogin(Login login);
        Task<Login> AuthUser(string userName);

    }
    public class LoginRepository : ILoginRepository
    {
        private readonly berriesdbContext _db;
        public LoginRepository(berriesdbContext db)
        {
            _db = db;
        }
        public async Task<Login> CreateLogin(string userName, string password, string email)
        {
            Login newLogin = new Login
            {
                UserName = userName,
                Password = password,
                Email = email,
                RegisterDate = DateTime.Now,
                StateDelete = false,
                ModifyDate = null,
                Verified = null
            };

            await _db.Login.AddAsync(newLogin);
            _db.SaveChanges();

            return newLogin;
        }

        public async Task<Login> DeleteLogin(Login login)
        {
            _db.Login.Attach(login); //Llamamos la actualizacion
            _db.Entry(login).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return login;
        }

        public async Task<List<Login>> GetAll()
        {
            return await _db.Login.ToListAsync();
        }

        public async Task<int?> GetIdByUsername(string username)
        {
            var usuario = await _db.Login.FirstOrDefaultAsync(u => u.UserName == username);
            return usuario?.IdLogin;
        }

        public async Task<Login> GetLogin(int idLogin)
        {
            return await _db.Login.FirstOrDefaultAsync(u => u.IdLogin == idLogin);
        }

        // AUTENTICACION------------------------------------------------------------------------------
        public async Task<Login> AuthUser(string userName)
        {
            return await _db.Login.FirstOrDefaultAsync(u => u.UserName == userName);
        }

        public async Task<Login> UpdateLogin(Login Login)
        {
            Login LoginUpdate = await _db.Login.FindAsync(Login.IdLogin);
            if (LoginUpdate != null)
            {
                LoginUpdate.UserName = Login.UserName;
                LoginUpdate.Password = Login.Password;
                LoginUpdate.Email = Login.Email;

                await _db.SaveChangesAsync();
            }
            return LoginUpdate;
        }


    }
}