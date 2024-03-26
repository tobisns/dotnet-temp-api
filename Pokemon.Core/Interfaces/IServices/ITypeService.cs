using Pokemon.Core.Entities.General;


namespace Pokemon.Core.Interfaces.IServices
{
    public interface ITypeService
    {
        Task<IEnumerable<Entities.General.Type>> GetTypes();
        Task<Entities.General.Type> Create(Entities.General.Type model);
        Task Update(int id, Entities.General.Type model);
        Task Delete(int id);
    }
}