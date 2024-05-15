using Sistema_de_Gestion_Moras.Migrations;
using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Repositories;
using System.Net;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace Sistema_de_Gestion_Moras.Services
{
    public interface ILoginService
    {
        Task<List<Login>> GetAll();
        Task<Login> GetLogin(int idLogin);
        Task<int?> GetIdByUsername(string username);
        Task<Login> CreateLogin(string userName, string password, string email);
        Task<Login> UpdateLogin(int idLogin, string? userName = null, string? password = null, string? email = null);
        Task<Login> DeleteLogin(int idLogin);
        Task<bool> Authentication(string userName, string password);
        string EncryptPassword(string password);
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
            password = EncryptPassword(password);
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

        public async Task<int?> GetIdByUsername(string username)
        {
            return await _loginRepository.GetIdByUsername(username);
            throw new NotImplementedException();
        }

        public async Task<Login> GetLogin(int idLogin)
        {
            return await _loginRepository.GetLogin(idLogin);
            throw new NotImplementedException();
        }


// ENCRIPTAR CONTRASEÑA ----------------------------------------------------------------------------
        public string EncryptPassword(string password)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(password));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
//AUTENTICACION----------------------------------------------------------------------------
        public async Task<bool> Authentication(string userName, string password)
        {
            var user = await _loginRepository.AuthUser(userName);
            string hashedPassword = EncryptPassword(password);

            if (user != null && (user.Password == hashedPassword))
                return true;
            return false;
            //return await _loginRepository.AuthUsername(userName, password);
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

