using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTier.Entities.Models;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Ürünler");
        builder.HasKey(x => x.Id);
        builder.Property(p => p.Price).HasColumnType("para");
    }
}
