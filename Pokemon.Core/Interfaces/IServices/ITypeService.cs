using Pokemon.Core.Entities.General;


namespace Pokemon.Core.Interfaces.IServices
{
    public interface ITypeService
    {
        Task<Entities.Business.ListTypes> GetTypes();
        Task<Entities.General.Type> Create(Entities.General.Type model);
        Task Update(int id, Entities.General.Type model);
        Task Delete(int id);
        Task<IEnumerable<PokemonType>> Assign(int id, Entities.Business.Pokemon model);
        Task<IEnumerable<PokemonType>> Unassign(int id, Entities.Business.Pokemon model);
        Task<Entities.Business.ListPokemonType> GetPokemonWithTypes(int id);
    }
}