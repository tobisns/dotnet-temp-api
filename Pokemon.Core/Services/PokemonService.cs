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

        public async Task<IEnumerable<Entities.General.Pokemon>> GetPokemonsPaginated(int pageNumber, int pageSize)
        {
            return await _pokemonRepository.GetPaginated(pageNumber, pageSize);
        }

        public async Task<Entities.General.Pokemon> Create(Entities.General.Pokemon model)
        {
            return await _pokemonRepository.Create(model);
        }

        public async Task Update(string name, Entities.General.Pokemon model)
        {
            var existingData = await _pokemonRepository.GetByName(name);

            //Manual mapping
            existingData.ImageUrl = model.ImageUrl;
            existingData.EvoTreeId = model.EvoTreeId;
            existingData.Height = model.Height;
            existingData.Weight = model.Weight;
            existingData.Hp = model.Hp;
            existingData.Atk = model.Atk;
            existingData.Def = model.Def;
            existingData.Sa = model.Sa;
            existingData.Sd = model.Sd;
            existingData.Spd = model.Spd;

            await _pokemonRepository.Update(existingData);
        }

        public async Task Delete(string name)
        {
            var entity = await _pokemonRepository.GetByName(name);
            await _pokemonRepository.Delete(entity);
        }
    }
}