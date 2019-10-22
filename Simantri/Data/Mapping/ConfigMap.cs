using Fathcore.EntityFramework.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Simantri.Data.Domain;

namespace Simantri.Data.Mapping
{
    public class ConfigMap : EntityTypeConfiguration<Config, int>
    {
        protected override void PostConfigure(EntityTypeBuilder<Config> builder)
        {
            builder.HasIndex(config => config.Key)
                .HasName(MappingDefaults.UniqueIndex(nameof(Config), nameof(Config.Key)))
                .IsUnique();

            base.PostConfigure(builder);
        }

        public override void Configure(EntityTypeBuilder<Config> builder)
        {
            builder.ToTable(nameof(Config));

            builder.Property(company => company.Key)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(company => company.Value)
                .HasDefaultValue("Not defined yet.")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(company => company.IsActive)
                .HasDefaultValue(true)
                .IsRequired();

            base.Configure(builder);
        }
    }
}
