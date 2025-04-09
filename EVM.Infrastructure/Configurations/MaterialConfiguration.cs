using EVM.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVM.Infrastructure.Configurations
{
    public class MaterialConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name).IsRequired().HasMaxLength(100);
            builder.Property(m => m.PricePerUnit).HasColumnType("decimal(18, 2)");

            builder.HasMany(m => m.Options)
                   .WithOne(mo => mo.Material)
                   .HasForeignKey(mo => mo.MaterialId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
               new Material { Id = 1, Name = "Projector", PricePerUnit = 30.00m },
               new Material { Id = 2, Name = "Sound System", PricePerUnit = 50.00m },
               new Material { Id = 3, Name = "Flip Chart", PricePerUnit = 10.00m }
           );
        }
    }
}
