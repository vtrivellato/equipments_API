using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data.Contexts
{
    public class ApiDBContext : DbContext
    {
        public ApiDBContext(DbContextOptions<ApiDBContext> options) : base(options) { }

        public DbSet<Equipamento> Equipamentos { get; set; }
        public DbSet<Alarme> Alarmes { get; set; }
        public DbSet<AlarmeAtuado> AlarmesAtuados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipamento>()
                .HasIndex(e =>  e.NumeroSerie)
                .IsUnique();
            
            modelBuilder.Entity<Equipamento>()
                .HasMany(e => e.Alarmes)
                .WithOne(a => a.Equipamento)
                .HasPrincipalKey(e => e.NumeroSerie)
                .HasForeignKey(a => a.EquipamentoPK)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}