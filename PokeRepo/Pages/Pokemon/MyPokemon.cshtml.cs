using Microsoft.AspNetCore.Mvc.RazorPages;
using PokeRepo.Database;
using PokeRepo.Models;

namespace PokeRepo.Pages.Pokemon
{
    public class MyPokemonModel(PokeDbContext context) : PageModel
    {
        private readonly PokeDbContext context = context;

        public List<PokemonRoot> Pokemons { get; set; }
        public void OnGet()
        {
            Pokemons = context.Pokemons.ToList();
        }
    }
}
