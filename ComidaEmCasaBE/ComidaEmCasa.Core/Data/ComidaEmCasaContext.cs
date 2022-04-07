using ComidaEmCasa.Core.Configuration;
using ComidaEmCasa.Model.Info;
using Microsoft.EntityFrameworkCore;

namespace ComidaEmCasa.Core.Data
{
    public class ComidaEmCasaContext : DbContext
    {
        public ComidaEmCasaContext(DbContextOptions<ComidaEmCasaContext> options) : base(options) { }
        public DbSet<UsuarioInfo> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioEntityConfiguration());
        }
    }
}
