using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Sistema_de_Gestion_Moras.Services
{
    public interface ISystemLoginService
    {
        Task<List<SystemLogin>> GetAll();
        Task<SystemLogin> GetSystemLogin(int idSystemLogin);
        Task<SystemLogin> CreateSystemLogin(string username, string password, int idPerson);
        Task<SystemLogin> UpdateSystemLogin(int idSystemLogin, string? username = null, string? password = null, int? idPerson = null);
        Task<SystemLogin> DeleteSystemLogin(int idSystemLogin);
        Task<bool> Authentication(string userName, string password);
        string GenerateToken(string username);

    }

    public class SystemLoginService : ISystemLoginService
    {
        public readonly ISystemLoginRepository _SystemLoginRepository;
        private readonly IConfiguration _configuration;

        public SystemLoginService(ISystemLoginRepository SystemLoginRepository, IConfiguration configuration)
        {
            _SystemLoginRepository = SystemLoginRepository;
            _configuration = configuration;
        }

        public async Task<SystemLogin> CreateSystemLogin(string username, string password, int idPerson)
        {
            return await _SystemLoginRepository.CreateSystemLogin(username, password, idPerson);
            throw new NotImplementedException();
        }

        public async Task<SystemLogin> DeleteSystemLogin(int idSystemLogin)
        {
            SystemLogin SystemLoginToDelete = await _SystemLoginRepository.GetSystemLogin(idSystemLogin);
            if (SystemLoginToDelete == null)
            {
                throw new Exception($"This SystemLogin with the Id {idSystemLogin} don´t exist. ");
            }
            SystemLoginToDelete.StateDelete = true;
            SystemLoginToDelete.ModifyDate = DateTime.Now;
            return await _SystemLoginRepository.DeleteSystemLogin(SystemLoginToDelete);
            throw new NotImplementedException();
        }

        public async Task<List<SystemLogin>> GetAll()
        {
            return await _SystemLoginRepository.GetAll();
            throw new NotImplementedException();
        }

        public async Task<SystemLogin> GetSystemLogin(int idSystemLogin)
        {
            return await _SystemLoginRepository.GetSystemLogin(idSystemLogin);
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
            var user = await _SystemLoginRepository.AuthUser(userName);
            string hashedPassword = EncryptPassword(password);

            if (user != null && (user.Password == hashedPassword))
                return true;
            return false;
            throw new NotImplementedException();
        }

        //TOKEN----------------------------------------------------------------------------

        public string GenerateToken(string username)
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

        public async Task<SystemLogin> UpdateSystemLogin(int idSystemLogin, string? username = null, string? password = null, int? idPerson = null)
        {
            SystemLogin newSystemLogin = await _SystemLoginRepository.GetSystemLogin(idSystemLogin);
            if (newSystemLogin != null)
            {

                if (username != null)
                {
                    newSystemLogin.Username = (string)username;
                }
                if (password != null)
                {
                    newSystemLogin.Password = (string)password;
                }
                if (idPerson != null)
                {
                    newSystemLogin.IdPerson = (int)idPerson;
                }

                return await _SystemLoginRepository.UpdateSystemLogin(newSystemLogin);
            }
            throw new NotImplementedException();
        }
    }
}