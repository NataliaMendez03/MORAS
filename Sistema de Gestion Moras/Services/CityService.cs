using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Repositories;

namespace Sistema_de_Gestion_Moras.Services
{
    public interface ICityService
    {
        Task<List<City>> GetAll();
        Task<City> GetCity(int idCity);
        Task<City> CreateCity(string nameCity);
        Task<City> UpdateCity(int idCity, string? nameCity = null);
        Task<City> DeleteCity(int idCity);
    }
    public class CityService : ICityService
    {
        public readonly ICityRepository _CityRepository;
        public CityService(ICityRepository CityRepository)
        {
            _CityRepository = CityRepository;
        }

        public async Task<City> CreateCity(string nameCity)
        {
            return await _CityRepository.CreateCity(nameCity);
        }

        public async Task<City> DeleteCity(int idCity)
        {
            // comprobar si existe
            City CityToDelete = await _CityRepository.GetCity(idCity);
            if (CityToDelete == null)
            {
                throw new Exception($"This City with the Id {idCity} don´t exist. ");
            }
            CityToDelete.StateDelete = true;
            CityToDelete.CreatedDate = DateTime.Now;
            return await _CityRepository.DeleteCity(CityToDelete);
        }

        public async Task<List<City>> GetAll()
        {
            return await _CityRepository.GetAll();
        }

        public async Task<City> GetCity(int idCity)
        {
            return await _CityRepository.GetCity(idCity);
        }

        public async Task<City> UpdateCity(int idCity, string? nameCity = null)
        {
            City newCity = await _CityRepository.GetCity(idCity);
            if (newCity != null)
            {
                if (nameCity != null)
                {
                    newCity.NameCity = (string)nameCity;
                }
                return await _CityRepository.UpdateCity(newCity);
            }
            throw new NotImplementedException();
        }
    }
}