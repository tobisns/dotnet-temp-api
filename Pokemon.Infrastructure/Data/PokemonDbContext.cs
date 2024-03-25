using Pokemon.Core.Entities.General;
using Microsoft.EntityFrameworkCore;

namespace Pokemon.Infrastructure.Data
{
    public class PokemonDbContext : DbContext
    {
        public DbSet<Core.Entities.General.Pokemon> Pokemons { get; set; }
        public DbSet<EvoTree> EvoTrees { get; set; }
        public DbSet<Core.Entities.General.Type> Types { get; set; }
        public DbSet<PokemonType> PokemonTypes { get; set; }

        public PokemonDbContext(DbContextOptions<PokemonDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Pokemon
            modelBuilder.Entity<Core.Entities.General.Pokemon>()
                .HasKey(p => p.Name);
            
            modelBuilder.Entity<Core.Entities.General.Pokemon>()
                .Property(p => p.Name)
                .HasMaxLength(32);
            
            modelBuilder.Entity<Core.Entities.General.Pokemon>()
                .Property(p => p.ImageUrl)
                .HasColumnType("TEXT");

            // EvoTree
            modelBuilder.Entity<EvoTree>()
                .HasKey(et => et.PokemonName);
            
            modelBuilder.Entity<EvoTree>()
                .HasOne(et => et.Pokemon)
                .WithOne(p => p.EvoTree)
                .HasForeignKey<EvoTree>(et => et.PokemonName)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EvoTree>()
                .Property(et => et.PokemonName)
                .HasMaxLength(32);

            // Type
            modelBuilder.Entity<Core.Entities.General.Type>()
                .HasKey(t => t.Id);
            
            modelBuilder.Entity<Core.Entities.General.Type>()
                .Property(t => t.Name)
                .HasMaxLength(32)
                .IsRequired();

            // PokemonType (Join Table)
            modelBuilder.Entity<PokemonType>()
                .HasKey(pt => new { pt.PokemonName, pt.TypeId });
            
            modelBuilder.Entity<PokemonType>()
                .HasOne(pt => pt.Pokemon)
                .WithMany(p => p.PokemonTypes)
                .HasForeignKey(pt => pt.PokemonName);

            modelBuilder.Entity<PokemonType>()
                .HasOne(pt => pt.Type)
                .WithMany(t => t.PokemonTypes)
                .HasForeignKey(pt => pt.TypeId);
        }
    }

    
}
