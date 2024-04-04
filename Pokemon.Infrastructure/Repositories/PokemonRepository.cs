using Pokemon.Core.Interfaces.IRepositories;
using Pokemon.Core.Exceptions;
﻿using Microsoft.EntityFrameworkCore;
using Pokemon.Infrastructure.Data;

namespace Pokemon.Infrastructure.Repositories
{
    //Unit of Work Pattern
    public class PokemonRepository : IPokemonRepository
    {
        protected readonly PokemonDbContext _dbContext;
        protected DbSet<Core.Entities.General.Pokemon> DbSet => _dbContext.Set<Pokemon.Core.Entities.General.Pokemon>();

        public PokemonRepository(PokemonDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Core.Entities.General.Pokemon>> GetAll()
        {
            var data = await _dbContext.Set<Core.Entities.General.Pokemon>()
                .AsNoTracking()
                .ToListAsync();

            return data;
        }

        public async Task<IEnumerable<Core.Entities.General.Pokemon>> GetPaginated(int pageNumber, int pageSize, string query)
        {
            var data = await _dbContext.Set<Core.Entities.General.Pokemon>()
                .Where(p => p.Name.ToUpper().Contains(query.ToUpper()))
                .Skip(pageNumber * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();

            return data;
        }

        public async Task<Core.Entities.General.Pokemon> Create(Core.Entities.General.Pokemon model)
        {
            await _dbContext.Set<Core.Entities.General.Pokemon>().AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }

        public async Task Update(Core.Entities.General.Pokemon model)
        {
            _dbContext.Set<Core.Entities.General.Pokemon>().Update(model);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Core.Entities.General.Pokemon model)
        {
            _dbContext.Set<Core.Entities.General.Pokemon>().Remove(model);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Core.Entities.General.Pokemon> GetByName(string name)
        {
            var data = await _dbContext.Set<Core.Entities.General.Pokemon>().FirstOrDefaultAsync(p => p.Name == name) ?? throw new NotFoundException("No data found");
            return data;
        }

        public async Task<IEnumerable<Core.Entities.General.Type>> GetTypes(string name)
        {
            var typeIds = _dbContext.Set<Core.Entities.General.PokemonType>()
                                    .Where(t => t.PokemonName.Equals(name))
                                    .Select(t => t.TypeId) // Select only the TypeId
                                    .AsEnumerable() // Switch to in-memory processing
                                    .Distinct() // Apply distinct
                                    .ToList(); // Materialize the result

            return await _dbContext.Types
            .Where(t => typeIds.Contains(t.Id))
            .ToListAsync();
        }
    }
}