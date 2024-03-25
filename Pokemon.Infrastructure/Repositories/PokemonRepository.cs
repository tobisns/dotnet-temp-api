using Pokemon.Core.Interfaces.IRepositories;
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
    }
}