using Pokemon.Core.Interfaces.IRepositories;
using Pokemon.Core.Entities.Business;
using Pokemon.Core.Interfaces.IServices;


namespace Pokemon.Core.Services
{
    public class TypeService : ITypeService
    {
        private readonly ITypeRepository _typeRepository;

        public TypeService(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public async Task<ListTypes> GetTypes()
        {
            var types = await _typeRepository.GetAll();
            var businessTypes = types.Select(generalType => new Pokemon.Core.Entities.Business.Type
            {
                Id = generalType.Id,
                Name = generalType.Name
                // You may need to add additional property mappings depending on your requirements
            });
            return new ListTypes { Types = businessTypes };
        }

        public async Task<Entities.General.Type> Create(Entities.General.Type model)
        {
            return await _typeRepository.Create(model);
        }

        public async Task Update(int id, Entities.General.Type model)
        {
            var existingData = await _typeRepository.GetById(id);

            //Manual mapping
            existingData.Name = model.Name;

            await _typeRepository.Update(existingData);
        }

        public async Task Delete(int id)
        {
            var entity = await _typeRepository.GetById(id);
            await _typeRepository.Delete(entity);
        }

        public async Task<IEnumerable<Entities.General.PokemonType>> Assign(int id, Entities.Business.Pokemon model)
        {
            return await _typeRepository.Assign(id, model.Name);
        }

        public async Task<IEnumerable<Entities.General.PokemonType>> Unassign(int id, Entities.Business.Pokemon model)
        {
            return await _typeRepository.Unassign(id, model.Name);
        }

        public async Task<ListPokemonType> GetPokemonWithTypes(int id)
        {
            var pokemonTypes = await _typeRepository.GetPokemonsWithType(id);
            var businessTypes = pokemonTypes.Select(generalType => new PokemonType
            {
                Name = generalType.PokemonName,
                TypeId = generalType.TypeId
                // You may need to add additional property mappings depending on your requirements
            });
            return new ListPokemonType { Pokemons = businessTypes };
        }
    }
}