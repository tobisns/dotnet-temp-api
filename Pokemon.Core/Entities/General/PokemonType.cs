using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokemon.Core.Entities.General
{
    public class PokemonType
    {
        public required string PokemonName { get; set; }
        public int TypeId { get; set; }

        // Navigation properties
        public required Pokemon Pokemon { get; set; }
        public required Type Type { get; set; }
    }
}