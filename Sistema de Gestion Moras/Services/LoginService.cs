using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sistema_de_Gestion_Moras.Migrations;
using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Runtime.Intrinsics.Arm;
using System.Security.Claims;
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
        string GenerarToken(string username);
    }

    public class LoginService : ILoginService
    {
        public readonly ILoginRepository _loginRepository;
        private readonly IConfiguration _configuration;
        public LoginService(ILoginRepository loginRepository, IConfiguration configuration)
        {
            _loginRepository = loginRepository;
            _configuration = configuration;
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
        private string EncryptPassword(string password)
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
            throw new NotImplementedException();
        }

        //TOKEN----------------------------------------------------------------------------

        public string GenerarToken(string username)
        {
            var key = _configuration.GetValue<string>("Jwt:key");
            var keyBytes = Encoding.ASCII.GetBytes(key);

            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.Name, username));
            claims.AddClaim(new Claim(ClaimTypes.Role, "User"));

            var credencialesToken = new SigningCredentials
                (
                    new SymmetricSecurityKey(keyBytes),
                    SecurityAlgorithms.HmacSha256Signature
                );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = credencialesToken
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

            string tokenCreado = tokenHandler.WriteToken(tokenConfig);

            return tokenCreado;


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
                    password = EncryptPassword(password);
                    newLogin.Password = (string)password;
                }
                if (email != null)
                {
                    newLogin.Email = (string)email;
                }

                return await _loginRepository.UpdateLogin(newLogin);
            }
            throw new NotImplementedException();
        }


    }

}

