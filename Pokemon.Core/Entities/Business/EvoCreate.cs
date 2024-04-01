using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Pokemon.Core.Entities.Business
{
    public class EvoCreate
    {
        [JsonPropertyName("evolution_create")]
        public required IEnumerable<EvoTree> Evolutions { get; set; }
    }

}