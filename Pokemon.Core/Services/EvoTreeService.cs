using Pokemon.Core.Entities.Business;
using Pokemon.Core.Interfaces.IRepositories;
using Pokemon.Core.Interfaces.IServices;


namespace Pokemon.Core.Services
{
    public class EvoTreeService : IEvoTreeService
    {
        private readonly IEvoTreeRepository _evoTreeRepository;

        public EvoTreeService(IEvoTreeRepository evoTreeRepository)
        {
            _evoTreeRepository = evoTreeRepository;
        }

        public async Task<ListEvoTree> Create(EvoCreate model) 
        {
            var generalModel = model.Evolutions.Select(businessModel => new Entities.General.EvoTree
            {
                Id = 0,
                PokemonName = businessModel.PokemonName,
                Level = businessModel.Level
                // You may need to add additional property mappings depending on your requirements
            });
            var _data = await _evoTreeRepository.Create(generalModel);

            var businessModel = _data.Select(generalModel => new EvoTree
            {
                Id = generalModel.Id,
                PokemonName = generalModel.PokemonName,
                Level = generalModel.Level
                // You may need to add additional property mappings depending on your requirements
            });

            return new ListEvoTree { Evolutions = businessModel };
        }

        public async Task<ListEvoTree> Update(int id, EvoCreate model) 
        {
            var generalModel = model.Evolutions.Select(businessModel => new Entities.General.EvoTree
            {
                Id = 0,
                PokemonName = businessModel.PokemonName,
                Level = businessModel.Level
                // You may need to add additional property mappings depending on your requirements
            });
            var _data = await _evoTreeRepository.Update(id, generalModel);

            var businessModel = _data.Select(generalModel => new EvoTree
            {
                Id = generalModel.Id,
                PokemonName = generalModel.PokemonName,
                Level = generalModel.Level
                // You may need to add additional property mappings depending on your requirements
            });
            
            return new ListEvoTree { Evolutions = businessModel };
        }

        public async Task<ListEvoTree> Delete(int id, ListPokemon model) 
        {
            var generalModel = model.Pokemons.Select(businessModel => new Entities.General.EvoTree
            {
                Id = id,
                PokemonName = businessModel.Name,
                // You may need to add additional property mappings depending on your requirements
            });
            var _data = await _evoTreeRepository.Delete(id, generalModel);

            var businessModel = _data.Select(generalModel => new EvoTree
            {
                Id = generalModel.Id,
                PokemonName = generalModel.PokemonName,
                Level = generalModel.Level
                // You may need to add additional property mappings depending on your requirements
            });
            
            return new ListEvoTree { Evolutions = businessModel };
        }

        public async Task<ListEvoTree> Get(int id) 
        {
            var _data = await _evoTreeRepository.Get(id);

            var businessModel = _data.Select(generalModel => new EvoTree
            {
                Id = generalModel.Id,
                PokemonName = generalModel.PokemonName,
                Level = generalModel.Level
                // You may need to add additional property mappings depending on your requirements
            });
            
            return new ListEvoTree { Evolutions = businessModel };
        }
    }
}