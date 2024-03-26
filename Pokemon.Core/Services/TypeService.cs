using Pokemon.Core.Interfaces.IRepositories;
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

        public async Task<IEnumerable<Entities.General.Type>> GetTypes()
        {
            return await _typeRepository.GetAll();
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
    }
}