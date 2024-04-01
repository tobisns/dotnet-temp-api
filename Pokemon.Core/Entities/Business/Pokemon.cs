using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Pokemon.Core.Entities.Business
{
    public class Stats
    {
        
        public int? Hp { get; set; }
        [JsonPropertyName("attack")]
        public int? Atk { get; set; }
        [JsonPropertyName("defense")]
        public int? Def { get; set; }
        [JsonPropertyName("special_attack")]
        public int? Sa { get; set; }
        [JsonPropertyName("special_defense")]
        public int? Sd { get; set; }
        [JsonPropertyName("speed")]
        public int? Spd { get; set; }
    }
    public class Pokemon
    {
        public string? Name { get; set; }
        [JsonPropertyName("image_url")]
        public string? ImageUrl { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
        [JsonPropertyName("evo_tree_id")]
        public int? EvoTreeId { get; set; }
        public Stats? Stat { get; set; }
        public IEnumerable<Type>? Types { get; set; }
    }
}