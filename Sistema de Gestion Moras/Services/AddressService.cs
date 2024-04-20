using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Repositories;

namespace Sistema_de_Gestion_Moras.Services
{
    public interface IAddressService
    {
        Task<List<Address>> GetAll();
        Task<Address> GetAddress(int idAddress);
        Task<Address> CreateAddress(string addres, int idCity);
        Task<Address> UpdateAddress(int idAddress, string? addres= null , int? quantity=null);
        Task<Address> DeleteAddress(int idAddress);
    }
    public class AddressService : IAddressService
    {
        public readonly IAddressRepository _AddressRepository;
        public AddressService(IAddressRepository AddressRepository)
        {
            _AddressRepository = AddressRepository;
        }
        public async Task<Address> CreateAddress(string addres, int idCity)
        {
            return await _AddressRepository.CreateAddress(addres, idCity);
            throw new NotImplementedException();
        }

        public async Task<Address> DeleteAddress(int idAddress)
        {
            // comprobar si existe
            Address AddressToDelete = await _AddressRepository.GetAddress(idAddress);
            if (AddressToDelete == null)
            {
                throw new Exception($"This Address with the Id {idAddress} don´t exist. ");
            }
            AddressToDelete.StateDelete = true;
            AddressToDelete.CreatedDate = DateTime.Now;
            return await _AddressRepository.DeleteAddress(AddressToDelete);
            throw new NotImplementedException();
        }

        public async Task<List<Address>> GetAll()
        {
            return await _AddressRepository.GetAll();
            throw new NotImplementedException();
        }

        public async Task<Address> GetAddress(int idAddress)
        {
            return await _AddressRepository.GetAddress(idAddress);
            throw new NotImplementedException();
        }

        public async Task<Address> UpdateAddress(int idAddress, string? addres = null, int? idCity = null)
        {
            Address newAddress = await _AddressRepository.GetAddress(idAddress);
            if (newAddress != null)
            {

                if (addres != null)
                {
                    newAddress.Addres = (string)addres;
                }
                if (idCity != null)
                {
                    newAddress.IdCity = (int)idCity;
                }
                return await _AddressRepository.UpdateAddress(newAddress);
            }
            throw new NotImplementedException();
        }
    }
}