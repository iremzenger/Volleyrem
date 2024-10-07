using Microsoft.EntityFrameworkCore;
using WebApplication6.Data;

namespace WebApplication6.Data
{
    public class VolleyballContext:DbContext
    {
        public VolleyballContext(DbContextOptions<VolleyballContext> options) : base(options) { }

        public DbSet<Player> Players => Set<Player>();
        public DbSet<Position> Positions => Set<Position>();
        public DbSet<Country> Countries => Set<Country>();
    }
}
