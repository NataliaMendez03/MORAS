using Sistema_de_Gestion_Moras.Models;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Context;
namespace Sistema_de_Gestion_Moras.Repositories
{
    public interface IClientRepository
    {
        Task<List<Client>> GetAll(); 
        Task<Client> GetClient(int idClient);
        Task<Client> CreateClient(int idPerson);
        Task<Client> UpdateClient(Client client);
        Task<Client> DeleteClient(Client client);
    }
    public class ClientRepository: IClientRepository
    {
        private readonly berriesdbContext _db;
        public ClientRepository(berriesdbContext db)
        {
            _db = db;
        }

        public async Task<Client> CreateClient(int idPerson)
        {
            Person? person = _db.Person.FirstOrDefault(ut => ut.IdPerson == idPerson);

            Client newClient = new Client
            {
                IdPerson = idPerson,
                StateDelete = false,
                ModifyDate = null
            };

            await _db.Client.AddAsync(newClient);
            _db.SaveChanges();
            return newClient;
            throw new NotImplementedException();
        }

        public async Task<Client> DeleteClient(Client client)
        {
            _db.Client.Attach(client); //Llamamos la actualizacion
            _db.Entry(client).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return client;
            throw new NotImplementedException();
        }

        public async Task<List<Client>> GetAll()
        {
            return await _db.Client.ToListAsync();
            throw new NotImplementedException();
        }

        public async Task<Client> GetClient(int idClient)
        {
            return await _db.Client.FirstOrDefaultAsync(u => u.IdClient == idClient);
            throw new NotImplementedException();
        }

        public async Task<Client> UpdateClient(Client client)
        {
            Client ConsultUpdate = await _db.Client.FindAsync(client.IdClient);
            if (ConsultUpdate != null)
            {
                ConsultUpdate.IdPerson = client.IdPerson;

                await _db.SaveChangesAsync();
            }

            return ConsultUpdate;
            throw new NotImplementedException();
        }
    }
}
