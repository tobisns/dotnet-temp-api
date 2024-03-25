using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokemon.Core.Entities.General
{
    public class Pokemon
    {
        public required string Name { get; set; }
        public string? ImageUrl { get; set; }
        public int EvoTreeId { get; set; } = -1;
        public int Height { get; set; } = 0;
        public int Weight { get; set; } = 0;
        public int Hp { get; set; } = 0;
        public int Atk { get; set; } = 0;
        public int Def { get; set; } = 0;
        public int Sa { get; set; } = 0;
        public int Sd { get; set; } = 0;
        public int Spd { get; set; } = 0;

        // Navigation properties
        public List<PokemonType>? PokemonTypes { get; set; }
        public EvoTree? EvoTree { get; set; }
    }
}