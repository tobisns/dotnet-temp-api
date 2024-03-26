using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokemon.Core.Entities.General
{
    public class Type
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        // Navigation property
        public List<PokemonType>? PokemonTypes { get; set; }
    }

}