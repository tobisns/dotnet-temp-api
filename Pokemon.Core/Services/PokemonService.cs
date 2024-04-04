using Pokemon.Core.Entities.Business;
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

        public async Task<ListPokemon> GetPokemons()
        {
            var pokemons = await _pokemonRepository.GetAll();
            var businessPokemons = pokemons.Select(generalPokemon => new Entities.Business.Pokemon
            {
                Name = generalPokemon.Name,
                ImageUrl = generalPokemon.ImageUrl,
                EvoTreeId = generalPokemon.EvoTreeId
                // You may need to add additional property mappings depending on your requirements
            });
            return new ListPokemon{ Pokemons = businessPokemons };
        }

        public async Task<ListPokemon> GetPokemonsPaginated(int pageNumber, int pageSize, string query)
        {
            var pokemons = await _pokemonRepository.GetPaginated(pageNumber, pageSize, query);
            var businessPokemons = pokemons.Select(generalPokemon => new Entities.Business.Pokemon
            {
                Name = generalPokemon.Name,
                ImageUrl = generalPokemon.ImageUrl,
                EvoTreeId = generalPokemon.EvoTreeId
                // You may need to add additional property mappings depending on your requirements
            });
            return new ListPokemon{ Pokemons = businessPokemons };
        }

        public async Task<Entities.General.Pokemon> Create(Entities.Business.Pokemon model)
        {
            var generalPokemon = new Entities.General.Pokemon
            {
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                Height = model.Height ?? 0,
                Weight = model.Weight ?? 0,
                Hp = model.Stat?.Hp ?? 0,
                Atk = model.Stat?.Atk ?? 0,
                Def = model.Stat?.Def ?? 0,
                Sa = model.Stat?.Sa ?? 0,
                Sd = model.Stat?.Sd ?? 0,
                Spd = model.Stat?.Spd ?? 0,
                // You may need to map additional properties here based on your requirements
            };

            return await _pokemonRepository.Create(generalPokemon);
        }

        public async Task Update(string name, Entities.Business.Pokemon model)
        {
            var existingData = await _pokemonRepository.GetByName(name);

            //Manual mapping
            existingData.ImageUrl = model.ImageUrl;
            existingData.EvoTreeId = model.EvoTreeId ?? existingData.EvoTreeId;
            existingData.Height = model.Height ?? existingData.Height;
            existingData.Weight = model.Weight ?? existingData.Weight;
            existingData.Hp = model.Stat?.Hp ?? existingData.Hp;
            existingData.Def = model.Stat?.Def ?? existingData.Def;
            existingData.Atk = model.Stat?.Atk ?? existingData.Atk;
            existingData.Sa = model.Stat?.Sa ?? existingData.Sa;
            existingData.Sd = model.Stat?.Sd ?? existingData.Sd;
            existingData.Spd = model.Stat?.Spd ?? existingData.Spd;

            await _pokemonRepository.Update(existingData);
        }

        public async Task Delete(string name)
        {
            var _entity = await _pokemonRepository.GetByName(name);
            await _pokemonRepository.Delete(_entity);
        }

        public async Task<Entities.Business.Pokemon> GetDetails(string name)
        {
            var _existingData = await _pokemonRepository.GetByName(name);
            var _types = await _pokemonRepository.GetTypes(name);
            var _businessTypes = _types.Select(generalType => new Entities.Business.Type
            {
                Name = generalType.Name,
                Id = generalType.Id
                // You may need to add additional property mappings depending on your requirements
            });
            var _resp = new Entities.Business.Pokemon {
                Name = _existingData.Name,
                ImageUrl = _existingData.ImageUrl,
                EvoTreeId = _existingData.EvoTreeId,
                Stat = new Stats {
                    Hp = _existingData.Hp,
                    Def = _existingData.Def,
                    Atk = _existingData.Atk,
                    Sa = _existingData.Sa,
                    Sd = _existingData.Sd,
                    Spd = _existingData.Spd
                },
                Weight = _existingData.Weight,
                Height = _existingData.Height,
                Types = _businessTypes
            };

            return _resp;
        }
    }
}