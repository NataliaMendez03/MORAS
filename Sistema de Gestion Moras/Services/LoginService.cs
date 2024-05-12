using Sistema_de_Gestion_Moras.Migrations;
using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Repositories;
using System.Net;

namespace Sistema_de_Gestion_Moras.Services
{
    public interface ILoginService
    {
        Task<List<Login>> GetAll();
        Task<Login> GetLogin(int idLogin);
        Task<Login> CreateLogin(string userName, string password, string email);
        Task<Login> UpdateLogin(int idLogin, string? userName = null, string? password =null, string? email=null);
        Task<Login> DeleteLogin(int idLogin);
        Task<Login> Login(string userName, string password);

    }

    public class LoginService : ILoginService
    {
        public readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<Login> CreateLogin(string userName, string password, string email)
        {
            return await _loginRepository.CreateLogin(userName, password, email);
            throw new NotImplementedException();
        }

        public async Task<Login> DeleteLogin(int idLogin)
        {
            Login LoginToDelete = await _loginRepository.GetLogin(idLogin);
            if (LoginToDelete == null)
            {
                throw new Exception($"This Login with the Id {idLogin} don´t exist. ");
            }
            LoginToDelete.StateDelete = true;
            LoginToDelete.ModifyDate = DateTime.Now;
            return await _loginRepository.DeleteLogin(LoginToDelete);
            throw new NotImplementedException();
        }

        public async Task<List<Login>> GetAll()
        {
            return await _loginRepository.GetAll();
            throw new NotImplementedException();
        }

        public async Task<Login> GetLogin(int idLogin)
        {
            return await _loginRepository.GetLogin(idLogin);
            throw new NotImplementedException();
        }

//AUTENTICACION----------------------------------------------------------------------------
        public async Task<Login> Login(string userName, string password)
        {
            return await _loginRepository.Login(userName, password);
            throw new NotImplementedException();

        }

        public async Task<Login> UpdateLogin(int idLogin, string? userName = null, string? password = null, string? email = null)
        {
            Login newLogin = await _loginRepository.GetLogin(idLogin);
            if (newLogin != null)
            {

                if (userName != null)
                {
                    newLogin.UserName = (string)userName;
                }
                if (password != null)
                {
                    newLogin.Password = (string)password;
                }
                if (email != null)
                {
                    newLogin.UserName = (string)email;
                }
                
                return await _loginRepository.UpdateLogin(newLogin);
            }
            throw new NotImplementedException();
        }
    }
}
