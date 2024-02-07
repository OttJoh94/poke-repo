using Microsoft.EntityFrameworkCore;

namespace PokeRepo.Database
{
    public class PokeDbContext(DbContextOptions<PokeDbContext> options) : DbContext(options)
    {

    }
}
