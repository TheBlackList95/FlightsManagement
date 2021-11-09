using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SuiviDesVols.Layers.Data;

namespace SuiviDesVols.Layers.DatabaseContexts
{
    public partial class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Aeroport> Aeroports { get; set; }
        public DbSet<Avion> Avions { get; set; }
        public DbSet<LigneVol> LigneVols { get; set; }
        public DbSet<Ville> Villes { get; set; }
        public DbSet<Vol> Vols { get; set; }
        public DbSet<VolOption> VolOptions { get; set; }
        public DbSet<Agence> Agences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
