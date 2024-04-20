using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Context;
using Sistema_de_Gestion_Moras.Models;

namespace Sistema_de_Gestion_Moras.Repositories
{
    public interface IAddressRepository
    {
        Task<List<Address>> GetAll();
        Task<Address> GetAddress(int idAddress);
        Task<Address> CreateAddress(string addres, int idCity);
        Task<Address> UpdateAddress(Address address);
        Task<Address> DeleteAddress(Address address);
    }
    public class AddressRepository : IAddressRepository
    {
        private readonly berriesdbContext _db;
        public AddressRepository(berriesdbContext db)
        {
            _db = db;
        }
        public async Task<Address> CreateAddress(string addres, int idCity)
        {
            Address newAddress = new Address
            {
                Addres = addres,
                IdCity = idCity,
                StateDelete = false,
                CreatedDate = null
            };

            await _db.Address.AddAsync(newAddress);
            _db.SaveChanges();

            return newAddress;
        }

        public async Task<Address> DeleteAddress(Address addres)
        {
            _db.Address.Attach(addres); //Llamamos la actualizacion
            _db.Entry(addres).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return addres;
        }

        public async Task<List<Address>> GetAll()
        {
            return await _db.Address.ToListAsync();
        }

        public async Task<Address> GetAddress(int idAddress)
        {
            return await _db.Address.FirstOrDefaultAsync(u => u.IdAddress == idAddress);
        }

        public async Task<Address> UpdateAddress(Address address)
        {
            Address AddressUpdate = await _db.Address.FindAsync(address.IdAddress);
            if (AddressUpdate != null)
            {
                //?? ConsultUpdate.IdConsult = idConsult;
                AddressUpdate.Addres = address.Addres;
                AddressUpdate.IdCity = address.IdCity;

                await _db.SaveChangesAsync();
            }
            return AddressUpdate;
        }
    }
}