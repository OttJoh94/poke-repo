using Microsoft.AspNetCore.Mvc.RazorPages;
using PokeRepo.Api;
using PokeRepo.Database;
using PokeRepo.Models;

namespace PokeRepo.Pages.Pokemon
{
    public class DetailsModel(PokeDbContext context) : PageModel
    {
        private readonly PokeDbContext context = context;

        public PokemonRoot Pokemon { get; set; }
        public string? ErrorMessage { get; set; }
        public bool PokemonAdded { get; set; } = false;
        public async Task OnGet(string name)
        {
            try
            {
                PokemonRoot pokemon = await new ApiCaller().MakeCall("pokemon", name);
                if (pokemon != null)
                {
                    Pokemon = pokemon;
                }

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        //Det här funkar inte som det ska
        public async Task OnPostAddMyPokemon(string name)
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
                        PokemonAdded = true;
                        return;
                    }

                    context.Pokemons.Add(pokemon);
                    context.SaveChanges();

                    PokemonAdded = true;
                }

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

        }
    }
}
