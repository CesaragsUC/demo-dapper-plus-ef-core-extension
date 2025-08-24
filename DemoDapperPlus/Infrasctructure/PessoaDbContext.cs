using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DemoDapperPlus.Infrasctructure
{
    public class PessoaDbContext : DbContext
    {
        public PessoaDbContext(DbContextOptions<PessoaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Entities.Pessoa> Pessoas { get; set; }
        public DbSet<Entities.Documento> Documentos { get; set; }
        public DbSet<Entities.Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PessoaDbContext).Assembly);
            modelBuilder.ApplyUtcDateTime();
        }

    }


}


public static class ModelBuilderExtensions
{
    public static void ApplyUtcDateTime(this ModelBuilder modelBuilder)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
            foreach (var p in entity.GetProperties().Where(p => p.ClrType == typeof(DateTime)))
            {
                p.SetValueConverter(new ValueConverter<DateTime, DateTime>(
                    v => v.Kind == DateTimeKind.Utc ? v : v.ToUniversalTime(),
                    v => DateTime.SpecifyKind(v, DateTimeKind.Utc)));
            }
    }
}