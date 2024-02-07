using PokeRepo.Models;

namespace PokeRepo.Database
{
    public class PokemonRepository(PokeDbContext context)
    {
        private readonly PokeDbContext context = context;

        public void AddPokemon(PokemonRoot newPokemon)
        {
            PokemonRoot? pokemonAlreadyExists = context.Pokemons.FirstOrDefault(p => p.Id == newPokemon.Id);

            if (pokemonAlreadyExists != null)
            {
                //Pokemon exists, don't add pokemon
                return;
            }

            context.Pokemons.Add(newPokemon);
            context.SaveChanges();

        }


    }
}
