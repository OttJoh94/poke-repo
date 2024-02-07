using Microsoft.AspNetCore.Mvc.RazorPages;
using PokeRepo.Database;
using PokeRepo.Models;

namespace PokeRepo.Pages.Pokemon
{
    public class MyPokemonModel(PokemonRepository repo) : PageModel
    {
        private readonly PokemonRepository repo = repo;

        public List<PokemonRoot> Pokemons { get; set; }
        public void OnGet()
        {
            Pokemons = repo.GetAllPokemons();
        }
    }
}
