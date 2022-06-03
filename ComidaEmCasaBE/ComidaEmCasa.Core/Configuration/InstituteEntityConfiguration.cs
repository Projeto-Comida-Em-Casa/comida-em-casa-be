using ComidaEmCasa.Model.Enums;
using ComidaEmCasa.Model.Info;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComidaEmCasa.Core.Configuration
{
    public class InstituteEntityConfiguration : IEntityTypeConfiguration<InstituteInfo>
    {
        public void Configure(EntityTypeBuilder<InstituteInfo> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Category).IsRequired().HasDefaultValue(InstituteCategoryEnum.Teaching);
            builder.Property(x => x.LogoPath);
            builder.HasOne(x => x.Owner).WithOne(us => us.Institute).HasForeignKey<InstituteInfo>(x => x.OwernId);
        }
    }
}
