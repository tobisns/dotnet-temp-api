using Pokemon.Core.Interfaces.IRepositories;
using Pokemon.Core.Exceptions;
﻿using Microsoft.EntityFrameworkCore;
using Pokemon.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Pokemon.Core.Entities.General;

namespace Pokemon.Infrastructure.Repositories
{
    //Unit of Work Pattern
    public class EvoTreeRepository : IEvoTreeRepository
    {
        protected readonly PokemonDbContext _dbContext;
        protected DbSet<EvoTree> DbSet => _dbContext.Set<Core.Entities.General.EvoTree>();
        public EvoTreeRepository(PokemonDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<EvoTree>> Create(IEnumerable<EvoTree> evoTrees) 
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try {
                    int maxId = await _dbContext.EvoTrees.MaxAsync(e => (int?)e.Id) ?? 0;
                    int nextId = maxId + 1;

                    foreach (var evoTree in evoTrees)
                    {
                        // Insert the EvoTree into the database
                        var _dat = new EvoTree {Id = nextId, Level = evoTree.Level, PokemonName = evoTree.PokemonName};
                        await _dbContext.EvoTrees.AddAsync(_dat);

                        // Update the Pokemon data's EvoTreeId to -1
                        var pokemonData = await _dbContext.Pokemons.SingleOrDefaultAsync(p => p.Name == evoTree.PokemonName);
                        
                        if (pokemonData != null)
                        {
                            pokemonData.EvoTreeId = nextId;
                        }

                        await _dbContext.SaveChangesAsync();
                    }

                    // Commit the transaction
                    await transaction.CommitAsync();

                    return await _dbContext.Set<EvoTree>()
                    .Where(t => t.Id.Equals(nextId))
                    .AsNoTracking()
                    .ToListAsync();
                }
                catch (Exception)
                {
                    // Rollback the transaction if an exception occurs
                    await transaction.RollbackAsync();
                    throw; // Re-throw the exception to handle it at a higher level if necessary
                }
            }
        }

        public async Task<IEnumerable<EvoTree>> Update(int id, IEnumerable<EvoTree> evoTrees) 
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try {
                    foreach (var evoTree in evoTrees)
                    {
                        // Insert the EvoTree into the database
                        var _dat = new EvoTree {Id = id, Level = evoTree.Level, PokemonName = evoTree.PokemonName};
                        await _dbContext.EvoTrees.AddAsync(_dat);

                        // Update the Pokemon data's EvoTreeId to -1
                        var pokemonData = await _dbContext.Pokemons.SingleOrDefaultAsync(p => p.Name == evoTree.PokemonName);
                        
                        if (pokemonData != null)
                        {
                            pokemonData.EvoTreeId = id;
                        }

                        await _dbContext.SaveChangesAsync();
                    }

                    // Commit the transaction
                    await transaction.CommitAsync();

                    return await _dbContext.Set<EvoTree>()
                    .Where(t => t.Id.Equals(id))
                    .AsNoTracking()
                    .ToListAsync();
                }
                catch (Exception)
                {
                    throw; // Re-throw the exception to handle it at a higher level if necessary
                }
            }
        }

        public async Task<IEnumerable<EvoTree>> Delete(int id, IEnumerable<EvoTree> evoTrees) 
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try {
                    if (!await _dbContext.EvoTrees.AnyAsync(e => e.Id == id)) {
                        await transaction.RollbackAsync();
                        throw new Exception("No EvoTree found with the specified id");
                    }

                    foreach (var evoTree in evoTrees)
                    {
                        // Insert the EvoTree into the database
                        var _dat = new EvoTree {Id = id, PokemonName = evoTree.PokemonName};
                        _dbContext.EvoTrees.Remove(_dat);

                        // Update the Pokemon data's EvoTreeId to -1
                        var pokemonData = await _dbContext.Pokemons.SingleOrDefaultAsync(p => p.Name == evoTree.PokemonName);
                        
                        if (pokemonData != null)
                        {
                            pokemonData.EvoTreeId = -1;
                        }

                        await _dbContext.SaveChangesAsync();
                    }

                    // Commit the transaction
                    await transaction.CommitAsync();
                    
                    return await _dbContext.Set<EvoTree>()
                    .Where(t => t.Id.Equals(id))
                    .AsNoTracking()
                    .ToListAsync();
                }
                catch (Exception)
                {
                    // Rollback the transaction if an exception occurs
                    await transaction.RollbackAsync();
                    throw; // Re-throw the exception to handle it at a higher level if necessary
                }
            }
        }

        public async Task<IEnumerable<EvoTree>> Get(int id) 
        {     
            return await _dbContext.Set<EvoTree>()
            .Where(t => t.Id.Equals(id))
            .AsNoTracking()
            .ToListAsync();
        }
    }
}