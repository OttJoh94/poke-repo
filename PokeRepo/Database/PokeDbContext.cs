using Microsoft.EntityFrameworkCore;
using PokeRepo.Models;

namespace PokeRepo.Database
{
    public class PokeDbContext(DbContextOptions<PokeDbContext> options) : DbContext(options)
    {
        public DbSet<PokemonRoot> Pokemons { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Species> Species { get; set; }
    }
}
