using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Repositories;
using System.Net;

namespace Sistema_de_Gestion_Moras.Services
{
    public interface IIdentificationTypeService
    {
        Task<List<IdentificationType>> GetAll();
        Task<IdentificationType> GetIdentificationType(int idIdentificationType);
        Task<IdentificationType> CreateIdentificationType(string identifiType);
        Task<IdentificationType> UpdateIdentificationType(int idIdentificationType, string? identifiType=null);
        Task<IdentificationType> DeleteIdentificationType(int idIdentificationType);
    }
    public class IdentificationTypeService: IIdentificationTypeService
    {
        public readonly IIdentificationTypeRepository _identiTypeRepository;
        public IdentificationTypeService(IIdentificationTypeRepository identiTypeRepository)
        {
            _identiTypeRepository = identiTypeRepository;
        }

        public async Task<IdentificationType> CreateIdentificationType(string identifiType)
        {
            return await _identiTypeRepository.CreateIdentificationType(identifiType);
        }

        public async Task<IdentificationType> DeleteIdentificationType(int idIdentificationType)
        {
            // comprobar si existe
            IdentificationType identificationTypeToDelete = await _identiTypeRepository.GetIdentificationType(idIdentificationType);
            if (identificationTypeToDelete == null)
            {
                throw new Exception($"This identification type with the Id {idIdentificationType} don´t exist. ");
            }
            identificationTypeToDelete.StateDelete = true;
            identificationTypeToDelete.ModifyDate = DateTime.Now;
            return await _identiTypeRepository.DeleteIdentificationType(identificationTypeToDelete);
        }

        public async Task<List<IdentificationType>> GetAll()
        {
            return await _identiTypeRepository.GetAll();
        }

        public async Task<IdentificationType> GetIdentificationType(int idIdentificationType)
        {
            return await _identiTypeRepository.GetIdentificationType(idIdentificationType);
        }

        public async Task<IdentificationType> UpdateIdentificationType(int idIdentificationType, string? identifiType = null)
        {
            IdentificationType newIdentiType = await _identiTypeRepository.GetIdentificationType(idIdentificationType);
            if (newIdentiType != null)
            {
                if (identifiType != null)
                {
                    newIdentiType.IdentifiType = (string)identifiType;
                }
                
                return await _identiTypeRepository.UpdateIdentificationType(newIdentiType);
            }
            throw new NotImplementedException();
        }
    }
}
