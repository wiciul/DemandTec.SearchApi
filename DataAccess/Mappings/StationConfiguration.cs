namespace DataAccess.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class StationConfiguration : IEntityTypeConfiguration<Station>
    {
        public void Configure(EntityTypeBuilder<Station> entity)
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            entity.Property(e => e.Name)
                .HasColumnType("varchar(255)");

            entity.HasIndex(e => new {e.Id, e.Name})
                .IsUnique();
        }
    }
}