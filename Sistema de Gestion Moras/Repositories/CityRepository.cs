using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Context;
using Sistema_de_Gestion_Moras.Models;

namespace Sistema_de_Gestion_Moras.Repositories
{
    public interface ICityRepository
    {
        Task<List<City>> GetAll();
        Task<City> GetCity(int idCity);
        Task<City> CreateCity(string nameCity);
        Task<City> UpdateCity(City city);
        Task<City> DeleteCity(City city);
    }
    public class CityRepository : ICityRepository
    {
        private readonly berriesdbContext _db;
        public CityRepository(berriesdbContext db)
        {
            _db = db;
        }
        public async Task<City> CreateCity(string nameCity)
        {
            City newCity = new City
            {
                NameCity = nameCity,
                StateDelete = false,
                CreatedDate = null
            };

            await _db.City.AddAsync(newCity);
            _db.SaveChanges();

            return newCity;
        }

        public async Task<City> DeleteCity(City city)
        {
            _db.City.Attach(city); //Llamamos la actualizacion
            _db.Entry(city).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return city;
        }

        public async Task<List<City>> GetAll()
        {
            return await _db.City.ToListAsync();
        }

        public async Task<City> GetCity(int idCity)
        {
            return await _db.City.FirstOrDefaultAsync(u => u.IdCity == idCity);
        }

        public async Task<City> UpdateCity(City city)
        {
            City CityUpdate = await _db.City.FindAsync(city.IdCity);
            if (CityUpdate != null)
            {
                CityUpdate.NameCity = city.NameCity;

                await _db.SaveChangesAsync();
            }
            return CityUpdate;
        }
    }
}
