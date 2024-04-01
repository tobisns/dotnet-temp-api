using Pokemon.Core.Entities.Business;
using Pokemon.Core.Entities.General;

namespace Pokemon.Core.Interfaces.IServices
{
    public interface IEvoTreeService
    {
        Task<ListEvoTree> Create(EvoCreate model);
        Task<ListEvoTree> Update(int id, EvoCreate model);
        Task<ListEvoTree> Delete(int id, ListPokemon model);
        Task<ListEvoTree> Get(int id);
    }
}