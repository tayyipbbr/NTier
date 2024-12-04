using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTier.Entities.Models;

namespace NTier.DataAccess.Configuration
{
    internal sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Kategori");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Name).HasColumnType("varchar(100)");
        }
    }
} // <>
