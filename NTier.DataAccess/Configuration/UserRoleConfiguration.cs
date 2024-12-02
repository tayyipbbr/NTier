using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTier.Entities.Models;

internal sealed class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("Kullanıcı Rol-Yetki")
        builder.HasKey(p => new {p.AppUserId, p.AppRoleId}); // composite key ile (birden fazla anahtar kelime ile) çift kelimeli id oluşturmuş olduk. tek olsaydı çakılırdı.
    }
}