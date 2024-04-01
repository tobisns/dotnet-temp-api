using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Pokemon.Core.Entities.Business
{
    public class EvoTree
    {
        public int? Id { get; set; }
        public int Level { get; set; }
        [JsonPropertyName("pokemon_name")]
        public required string PokemonName { get; set; }
    }

}