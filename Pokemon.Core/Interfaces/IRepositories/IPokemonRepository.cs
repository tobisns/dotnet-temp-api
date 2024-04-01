using Pokemon.Core.Entities.General;
using System.Threading.Tasks;

namespace Pokemon.Core.Interfaces.IRepositories
{
    //Unit of Work Pattern
    public interface IPokemonRepository
    {
        Task<IEnumerable<Entities.General.Pokemon>> GetAll();
        Task<IEnumerable<Entities.General.Pokemon>> GetPaginated(int pageNumber, int pageSize);
        Task<Entities.General.Pokemon> Create(Entities.General.Pokemon model);
        Task Update(Entities.General.Pokemon model);
        Task<Entities.General.Pokemon> GetByName(string name);
        Task Delete(Entities.General.Pokemon model);
        Task<IEnumerable<Entities.General.Type>> GetTypes(string name);
    }
}