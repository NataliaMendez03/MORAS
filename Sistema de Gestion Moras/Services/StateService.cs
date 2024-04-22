using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Repositories;
using System.Net;

namespace Sistema_de_Gestion_Moras.Services
{
    public interface IStateService
    {
        Task<List<State>> GetAll();
        Task<State> GetState(int idState);
        Task<State> CreateState(string nameState);
        Task<State> UpdateState(int idState, string? nameState=null);
        Task<State> DeleteState(int idState);
    }
    public class StateService: IStateService
    {
        public readonly IStateRepository _stateRepository;
        public StateService(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public async Task<State> CreateState(string nameState)
        {
            return await _stateRepository.CreateState(nameState);
        }

        public async Task<State> DeleteState(int idState)
        {
            // comprobar si existe
            State stateToDelete = await _stateRepository.GetState(idState);
            if (stateToDelete == null)
            {
                throw new Exception($"This state with the Id {idState} don´t exist. ");
            }
            stateToDelete.StateDelete = true;
            stateToDelete.ModifyDate = DateTime.Now;
            return await _stateRepository.DeleteState(stateToDelete);
        }

        public async Task<List<State>> GetAll()
        {
            return await _stateRepository.GetAll();
        }

        public async Task<State> GetState(int idState)
        {
            return await _stateRepository.GetState(idState);
        }

        public async Task<State> UpdateState(int idState, string? nameState = null)
        {
            State newState = await _stateRepository.GetState(idState);
            if (newState != null)
            {
                if (nameState != null)
                {
                    newState.NameState = (string)nameState;
                }
                
                return await _stateRepository.UpdateState(newState);
            }
            throw new NotImplementedException();
        }
    }
}
