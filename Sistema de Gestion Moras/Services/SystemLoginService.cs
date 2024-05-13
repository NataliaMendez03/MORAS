using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Repositories;

namespace Sistema_de_Gestion_Moras.Services
{
    public interface ISystemLoginService
    {
        Task<List<SystemLogin>> GetAll();
        Task<SystemLogin> GetSystemLogin(int idSystemLogin);
        Task<SystemLogin> CreateSystemLogin(string username, string password, int idPerson);
        Task<SystemLogin> UpdateSystemLogin(int idSystemLogin, string? username = null, string? password = null, int? idPerson = null);
        Task<SystemLogin> DeleteSystemLogin(int idSystemLogin);
        Task<SystemLogin> SystemLogin(string username, string password);

    }

    public class SystemLoginService : ISystemLoginService
    {
        public readonly ISystemLoginRepository _SystemLoginRepository;
        public SystemLoginService(ISystemLoginRepository SystemLoginRepository)
        {
            _SystemLoginRepository = SystemLoginRepository;
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

        //AUTENTICACION----------------------------------------------------------------------------
        public async Task<SystemLogin> SystemLogin(string username, string password)
        {
            return await _SystemLoginRepository.SystemLogin(username, password);
            throw new NotImplementedException();

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
