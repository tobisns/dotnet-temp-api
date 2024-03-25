using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokemon.Core.Entities.General
{
    public class EvoTree
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public required string PokemonName { get; set; }

        // Navigation properties
        public required Pokemon Pokemon { get; set; }
    }

}