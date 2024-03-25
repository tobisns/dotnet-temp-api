using Pokemon.Core.Entities.General;

namespace Pokemon.Core.Interfaces.IServices
{
    public interface IPokemonService
    {
        Task<IEnumerable<Entities.General.Pokemon>> GetPokemons();
        Task<IEnumerable<Entities.General.Pokemon>> GetPokemonsPaginated(int pageNumber, int pageSize);
        Task<Entities.General.Pokemon> Create(Entities.General.Pokemon model);
        Task Update(string name, Entities.General.Pokemon model);
        Task Delete(string name);
    }
}