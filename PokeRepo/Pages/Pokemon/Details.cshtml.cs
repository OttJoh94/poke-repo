using Microsoft.AspNetCore.Mvc.RazorPages;
using PokeRepo.Api;
using PokeRepo.Database;
using PokeRepo.Models;

namespace PokeRepo.Pages.Pokemon
{
	public class DetailsModel : PageModel
	{
		private readonly PokeDbContext context;

		public DetailsModel(PokeDbContext context)
		{
			this.context = context;
		}

		public PokemonRoot Pokemon { get; set; }
		public string? ErrorMessage { get; set; }
		public async Task OnGet(string name)
		{
			try
			{
				PokemonRoot pokemon = await new ApiCaller().MakeCall("pokemon", name);
				if (pokemon != null)
				{
					Pokemon = pokemon;

					PokemonRoot? pokemonAlreadyExists = context.Pokemons.FirstOrDefault(p => p.Id == pokemon.Id);

					if (pokemonAlreadyExists != null)
					{
						//Pokemon exists, don't add pokemon
						return;
					}

					context.Pokemons.Add(pokemon);
					context.SaveChanges();
				}

			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
			}
		}
	}
}
