using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokemon.Core.Entities.General
{
    public class Type
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        // Navigation property
        public required List<PokemonType> PokemonTypes { get; set; }
    }

}