using Pokemon.Core.Entities.General;

namespace Pokemon.Core.Interfaces.IServices
{
    public interface IPokemonService
    {
        Task<IEnumerable<Entities.General.Pokemon>> GetPokemons();
    }
}