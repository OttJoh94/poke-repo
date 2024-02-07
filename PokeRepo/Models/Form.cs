using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations;

namespace PokeRepo.Models
{
    public class Form
    {
        [Key]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        public int PokemonId { get; set; }
        public PokemonRoot? Pokemon { get; set; }
    }
}
