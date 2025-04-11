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
    public class CateringOptionConfiguration : IEntityTypeConfiguration<CateringOption>
    {
        public void Configure(EntityTypeBuilder<CateringOption> builder)
        {
            builder.HasKey(co => co.Id); // Explicit primary key

            builder.HasOne(co => co.Event)
                   .WithMany(e => e.CateringOptions)
                   .HasForeignKey(co => co.EventId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(co => co.Catering)
                   .WithMany(c => c.Options)
                   .HasForeignKey(co => co.CateringId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(co => new { co.EventId, co.CateringId }).IsUnique();

            var event1Id = Guid.Parse("a1b2c3d4-e5f6-7890-1234-567890abcdef");
            var event2Id = Guid.Parse("fedcba98-7654-3210-fedc-ba9876543210");
            var co1Id = Guid.Parse("6CF60C32-0902-4FAC-B20B-A34A0C178583");
            var co2Id = Guid.Parse("044FAF38-8339-4E06-B190-D1410CBBCC9D");

            builder.HasData(
                new CateringOption { Id = co1Id, EventId = event1Id, CateringId = 2, NumberOfPeople = 150 },
                new CateringOption { Id = co2Id, EventId = event2Id, CateringId = 3, NumberOfPeople = 40 }
            );
        }
    }
}
