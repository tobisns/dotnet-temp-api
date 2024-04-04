using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Pokemon.Core.Entities.Business
{
    public class PokemonType
    {
        public required string Name { get; set; }

        [JsonPropertyName("type_id")]
        public int TypeId { get; set; }
    }
}