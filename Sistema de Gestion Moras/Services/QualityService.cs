using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Repositories;

namespace Sistema_de_Gestion_Moras.Services
{
    public interface IQualityService
    {
        Task<List<Quality>> GetAll();
        Task<Quality> GetQuality(int idQuality);
        Task<Quality> CreateQuality(string nQuality, string quantity);
        Task<Quality> UpdateQuality(int idQuality, string? nQuality=null, string? quantity = null);
        Task<Quality> DeleteQuality(int idQuality);
    }
    public class QualityService : IQualityService
    {
        public readonly IQualityRepository _QualityRepository;
        public QualityService(IQualityRepository QualityRepository)
        {
            _QualityRepository = QualityRepository;
        }
        public async Task<Quality> CreateQuality(string nQuality, string quantity)
        {
            return await _QualityRepository.CreateQuality(nQuality, quantity);
            throw new NotImplementedException();
        }

        public async Task<Quality> DeleteQuality(int idQuality)
        {
            // comprobar si existe
            Quality QualityToDelete = await _QualityRepository.GetQuality(idQuality);
            if (QualityToDelete == null)
            {
                throw new Exception($"This Quality with the Id {idQuality} don´t exist. ");
            }
            QualityToDelete.StateDelete = true;
            QualityToDelete.ModifyDate = DateTime.Now;
            return await _QualityRepository.DeleteQuality(QualityToDelete);
            throw new NotImplementedException();
        }

        public async Task<List<Quality>> GetAll()
        {
            return await _QualityRepository.GetAll();
            throw new NotImplementedException();
        }

        public async Task<Quality> GetQuality(int idQuality)
        {
            return await _QualityRepository.GetQuality(idQuality);
            throw new NotImplementedException();
        }

        public async Task<Quality> UpdateQuality(int idQuality, string? nQuality = null, string? quantity = null)
        {
            Quality newQuality = await _QualityRepository.GetQuality(idQuality);
            if (newQuality != null)
            {

                if (nQuality != null)
                {
                    newQuality.NQuality = (string)nQuality;
                }
                if (quantity != null)
                {
                    newQuality.Quantity = (string)quantity;
                }
                return await _QualityRepository.UpdateQuality(newQuality);
            }
            throw new NotImplementedException();
        }
    }
}