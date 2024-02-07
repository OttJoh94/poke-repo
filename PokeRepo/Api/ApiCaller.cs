using Newtonsoft.Json;
using PokeRepo.Models;

namespace PokeRepo.Api
{
	public class ApiCaller
	{
		public HttpClient Client { get; set; }

		public ApiCaller()
		{
			Client = new();

			Client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");

		}

		public async Task<PokemonRoot> MakeCall(string url, string name)
		{
			HttpResponseMessage response = await Client.GetAsync($"{url}/{name.ToLower()}");

			if (response.IsSuccessStatusCode)
			{
				string json = await response.Content.ReadAsStringAsync();

				PokemonRoot pokemon = JsonConvert.DeserializeObject<PokemonRoot>(json);

				if (pokemon != null)
				{
					return pokemon;
				}

			}

			throw new HttpRequestException();

		}
	}
}
