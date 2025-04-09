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
    public class CateringConfiguration : IEntityTypeConfiguration<Catering>
    {
        public void Configure(EntityTypeBuilder<Catering> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).HasMaxLength(100);
            builder.Property(c => c.PricePerPerson).HasColumnType("decimal(18, 2)");

            builder.HasMany(c => c.Options)
                   .WithOne(co => co.Catering)
                   .HasForeignKey(co => co.CateringId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Seeding Catering data
            builder.HasData(
                new Catering { Id = 1, Name = "Standard Package", PricePerPerson = 25.00m },
                new Catering { Id = 2, Name = "Deluxe Menu", PricePerPerson = 40.00m },
                new Catering { Id = 3, Name = "Coffee Break", PricePerPerson = 10.00m }
            );
        }
    }
}
