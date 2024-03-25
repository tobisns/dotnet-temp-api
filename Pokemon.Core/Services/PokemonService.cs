using Pokemon.Core.Interfaces.IRepositories;
using Pokemon.Core.Interfaces.IServices;


namespace Pokemon.Core.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonService(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public async Task<IEnumerable<Entities.General.Pokemon>> GetPokemons()
        {
            return await _pokemonRepository.GetAll();
        }
    }
}