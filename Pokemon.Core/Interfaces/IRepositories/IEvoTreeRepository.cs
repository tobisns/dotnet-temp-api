using Pokemon.Core.Entities.General;
using System.Threading.Tasks;

namespace Pokemon.Core.Interfaces.IRepositories
{
    //Unit of Work Pattern
    public interface IEvoTreeRepository
    {
        Task<IEnumerable<EvoTree>> Create(IEnumerable<EvoTree> evoTrees);
        Task<IEnumerable<EvoTree>> Update(int id, IEnumerable<EvoTree> evoTrees);
        Task<IEnumerable<EvoTree>> Delete(int id, IEnumerable<EvoTree> evoTrees);
        Task<IEnumerable<EvoTree>> Get(int id);
    }
}