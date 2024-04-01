using Pokemon.Core.Entities.General;
using System.Threading.Tasks;

namespace Pokemon.Core.Interfaces.IRepositories
{
    //Unit of Work Pattern
    public interface ITypeRepository
    {
        Task<IEnumerable<Entities.General.Type>> GetAll();
        Task<Entities.General.Type> Create(Entities.General.Type model);
        Task Update(Entities.General.Type model);
        Task<Entities.General.Type> GetById<Tid>(Tid id);
        Task Delete(Entities.General.Type model);
        Task<IEnumerable<PokemonType>> Assign<Tid>(Tid id, string name);
        Task<IEnumerable<PokemonType>> Unassign<Tid>(Tid id, string name);
    }
}