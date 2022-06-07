using Microsoft.EntityFrameworkCore;

namespace vieraskirja.Data
{
    public class VieraskirjaContext : DbContext
    {
        public VieraskirjaContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Kirjoitus> Kirjoitukset { get; set; } = null!;
    }
}
