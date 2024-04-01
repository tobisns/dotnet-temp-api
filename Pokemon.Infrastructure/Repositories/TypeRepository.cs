using Pokemon.Core.Interfaces.IRepositories;
using Pokemon.Core.Exceptions;
﻿using Microsoft.EntityFrameworkCore;
using Pokemon.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Pokemon.Infrastructure.Repositories
{
    //Unit of Work Pattern
    public class TypeRepository : ITypeRepository
    {
        protected readonly PokemonDbContext _dbContext;
        protected DbSet<Core.Entities.General.Type> DbSet => _dbContext.Set<Core.Entities.General.Type>();

        public TypeRepository(PokemonDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Core.Entities.General.Type>> GetAll()
        {
            var data = await _dbContext.Set<Core.Entities.General.Type>()
                .AsNoTracking()
                .ToListAsync();

            return data;
        }

        public async Task<Core.Entities.General.Type> Create(Core.Entities.General.Type model)
        {
            await _dbContext.Set<Core.Entities.General.Type>().AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }

        public async Task Update(Core.Entities.General.Type model)
        {
            _dbContext.Set<Core.Entities.General.Type>().Update(model);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Core.Entities.General.Type model)
        {
            _dbContext.Set<Core.Entities.General.Type>().Remove(model);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Core.Entities.General.Type> GetById<Tid>(Tid id)
        {
            var data = await _dbContext.Set<Core.Entities.General.Type>().FindAsync(id) ?? throw new NotFoundException("No data found");
            return data;
        }

        public async Task<IEnumerable<Core.Entities.General.PokemonType>> Assign<Tid>(Tid id, string name)
        {
            var typedata = await _dbContext.Set<Core.Entities.General.Type>().FindAsync(id) ?? throw new NotFoundException("No data found");
            var pokemondata = await _dbContext.Set<Core.Entities.General.Pokemon>().FirstOrDefaultAsync(p => p.Name == name) ?? throw new NotFoundException("No data found");
            var model = new Core.Entities.General.PokemonType { TypeId = typedata.Id, PokemonName = name, Type = typedata, Pokemon = pokemondata };

            await _dbContext.Set<Core.Entities.General.PokemonType>().AddAsync(model);
            await _dbContext.SaveChangesAsync();

            return await _dbContext.Set<Core.Entities.General.PokemonType>()
                .Where(t => t.TypeId.Equals(typedata.Id))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Core.Entities.General.PokemonType>> Unassign<Tid>(Tid id, string name)
        {
            var typedata = await _dbContext.Set<Core.Entities.General.Type>().FindAsync(id) ?? throw new NotFoundException("No data found");
            var pokemondata = await _dbContext.Set<Core.Entities.General.Pokemon>().FirstOrDefaultAsync(p => p.Name == name) ?? throw new NotFoundException("No data found");
            var model = new Core.Entities.General.PokemonType { TypeId = typedata.Id, PokemonName = name, Type = typedata, Pokemon = pokemondata };

            _dbContext.Set<Core.Entities.General.PokemonType>().Remove(model);
            await _dbContext.SaveChangesAsync();

            return await _dbContext.Set<Core.Entities.General.PokemonType>()
                .Where(t => t.TypeId.Equals(typedata.Id))
                .AsNoTracking()
                .ToListAsync();
        }
    }
}