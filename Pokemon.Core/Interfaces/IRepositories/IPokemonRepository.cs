using Pokemon.Core.Entities.General;
using System.Threading.Tasks;

namespace Pokemon.Core.Interfaces.IRepositories
{
    //Unit of Work Pattern
    public interface IPokemonRepository
    {
        Task<IEnumerable<Entities.General.Pokemon>> GetAll();
    }
}