using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Context;
using Sistema_de_Gestion_Moras.Models;
using System.Net;

namespace Sistema_de_Gestion_Moras.Repositories
{
    public interface IStateRepository
    {
        Task<List<State>> GetAll();
        Task<State> GetState(int idState);
        Task<State> CreateState(string nameState);
        Task<State> UpdateState(State state);
        Task<State> DeleteState(State state);
    }
    public class StateRepository: IStateRepository
    {
        private readonly berriesdbContext _db;
        public StateRepository(berriesdbContext db)
        {
            _db = db;
        }

        public async Task<State> CreateState(string nameState)
        {
            State newState = new State
            {
                NameState = nameState,
                StateDelete = false,
                CreatedDate = null
            };

            await _db.State.AddAsync(newState);
            _db.SaveChanges();

            return newState;
        }

        public async Task<State> DeleteState(State state)
        {
            _db.State.Attach(state); //Llamamos la actualizacion
            _db.Entry(state).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return state;
        }

        public async Task<List<State>> GetAll()
        {
            return await _db.State.ToListAsync();
        }

        public async Task<State> GetState(int idState)
        {
            return await _db.State.FirstOrDefaultAsync(u => u.IdState == idState);
        }

        public async Task<State> UpdateState(State state)
        {
            State StateUpdate = await _db.State.FindAsync(state.IdState);
            if (StateUpdate != null)
            {
                StateUpdate.NameState = state.NameState;

                await _db.SaveChangesAsync();
            }
            return StateUpdate;
        }
    }
}
