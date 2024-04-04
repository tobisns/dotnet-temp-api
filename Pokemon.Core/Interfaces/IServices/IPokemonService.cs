using Pokemon.Core.Entities.General;

namespace Pokemon.Core.Interfaces.IServices
{
    public interface IPokemonService
    {
        Task<Entities.Business.ListPokemon> GetPokemons();
        Task<Entities.Business.ListPokemon> GetPokemonsPaginated(int pageNumber, int pageSize, string query);
        Task<Entities.General.Pokemon> Create(Entities.Business.Pokemon model);
        Task Update(string name, Entities.Business.Pokemon model);
        Task Delete(string name);
        Task<Entities.Business.Pokemon> GetDetails(string name);
    }
}