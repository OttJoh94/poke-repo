using Microsoft.AspNetCore.Mvc.RazorPages;
using PokeRepo.Api;
using PokeRepo.Models;

namespace PokeRepo.Pages.Pokemon
{
	public class DetailsModel : PageModel
	{
		public PokemonRoot Pokemon { get; set; }
		public string? ErrorMessage { get; set; }
		public async Task OnGet(string name)
		{
			try
			{
				PokemonRoot pokemon = await new ApiCaller().MakeCall("pokemon", name);
				Pokemon = pokemon;
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
			}
		}
	}
}
