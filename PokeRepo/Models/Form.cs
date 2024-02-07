using Newtonsoft.Json;

namespace PokeRepo.Models
{
	public class Form
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("url")]
		public string Url { get; set; }
	}
}
