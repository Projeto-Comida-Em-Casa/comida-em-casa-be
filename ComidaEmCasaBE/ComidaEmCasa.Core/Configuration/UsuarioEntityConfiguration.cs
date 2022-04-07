using ComidaEmCasa.Model.Info;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComidaEmCasa.Core.Configuration
{
    public class UsuarioEntityConfiguration : IEntityTypeConfiguration<UsuarioInfo>
    {
        public void Configure(EntityTypeBuilder<UsuarioInfo> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}
