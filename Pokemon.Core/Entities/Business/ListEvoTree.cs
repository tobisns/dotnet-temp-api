using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Pokemon.Core.Entities.Business
{
    public class ListEvoTree
    {
        [JsonPropertyName("evolution_data")]
        public required IEnumerable<EvoTree> Evolutions { get; set; }
    }

}