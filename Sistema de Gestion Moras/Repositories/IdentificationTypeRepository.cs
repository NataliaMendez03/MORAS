using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Context;
using Sistema_de_Gestion_Moras.Models;
using System.Net;

namespace Sistema_de_Gestion_Moras.Repositories
{
    public interface IIdentificationTypeRepository
    {
        Task<List<IdentificationType>> GetAll();
        Task<IdentificationType> GetIdentificationType(int idIdentificationType);
        Task<IdentificationType> CreateIdentificationType(string identifiType);
        Task<IdentificationType> UpdateIdentificationType(IdentificationType identificationType);
        Task<IdentificationType> DeleteIdentificationType(IdentificationType identificationType);
    }
    public class IdentificationTypeRepository: IIdentificationTypeRepository
    {
        private readonly berriesdbContext _db;
        public IdentificationTypeRepository(berriesdbContext db)
        {
            _db = db;
        }

        public async Task<IdentificationType> CreateIdentificationType(string identifiType)
        {
            IdentificationType newIdentificationType = new IdentificationType
            {
                IdentifiType = identifiType,
                StateDelete = false,
                ModifyDate = null
            };

            await _db.IdentificationType.AddAsync(newIdentificationType);
            _db.SaveChanges();

            return newIdentificationType;
        }

        public async Task<IdentificationType> DeleteIdentificationType(IdentificationType identificationType)
        {
            _db.IdentificationType.Attach(identificationType); //Llamamos la actualizacion
            _db.Entry(identificationType).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return identificationType;
        }

        public async Task<List<IdentificationType>> GetAll()
        {
            return await _db.IdentificationType.ToListAsync();
        }

        public async Task<IdentificationType> GetIdentificationType(int idIdentificationType)
        {
            return await _db.IdentificationType.FirstOrDefaultAsync(u => u.IdIdentificationType == idIdentificationType);
        }

        public async Task<IdentificationType> UpdateIdentificationType(IdentificationType identificationType)
        {
            IdentificationType identificationTypeUpdate = await _db.IdentificationType.FindAsync(identificationType.IdIdentificationType);
            if (identificationTypeUpdate != null)
            {
                //?? ConsultUpdate.IdConsult = idConsult;
                identificationTypeUpdate.IdentifiType = identificationType.IdentifiType;


                await _db.SaveChangesAsync();
            }

            return identificationTypeUpdate;
            throw new NotImplementedException();
        }
    }
}
