using Microsoft.EntityFrameworkCore;

namespace CoordinateLookup.Data
{
    public class CoordinateLookupDbContext: DbContext
    {
        public CoordinateLookupDbContext(DbContextOptions<CoordinateLookupDbContext> options)
            : base(options)
        {
        }
        public DbSet<Province> Provinces => Set<Province>();
        public DbSet<District> Districts => Set<District>();
        public DbSet<Town> Towns => Set<Town>();
        public DbSet<Neighbourhood> Neighbourhoods => Set<Neighbourhood>();

    }
}
