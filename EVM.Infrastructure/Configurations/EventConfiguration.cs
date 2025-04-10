using EVM.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVM.Domain.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EVM.Infrastructure.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            EnumToStringConverter<EventType> converter = new EnumToStringConverter<EventType>();

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasMaxLength(200);
            builder.Property(e => e.Status).HasDefaultValue(EventStatus.Upcoming);
            builder.Property(e => e.Type).HasConversion(converter);

            builder.HasOne(e => e.Client)
                   .WithMany(c => c.Events)
                   .HasForeignKey(e => e.ClientId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.RoomReservations)
                   .WithOne(rr => rr.Event)
                   .HasForeignKey(rr => rr.EventId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.MaterialOptions)
                   .WithOne(mo => mo.Event)
                   .HasForeignKey(mo => mo.EventId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.CateringOptions)
                   .WithOne(co => co.Event)
                   .HasForeignKey(co => co.EventId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.Tickets)
                   .WithOne(t => t.Event)
                   .HasForeignKey(t => t.EventId)
                   .OnDelete(DeleteBehavior.Cascade);

            var event1Id = Guid.Parse("a1b2c3d4-e5f6-7890-1234-567890abcdef");
            var event2Id = Guid.Parse("fedcba98-7654-3210-fedc-ba9876543210");

            builder.HasData(
                new Event
                {
                    Id = event1Id,
                    ClientId = 1,
                    Type = EventType.Conference,
                    Name = "Annual Tech Conference",
                    Description = "The premier tech event of the year.",
                    StartDate = new DateTime(2025, 5, 15, 9, 0, 0),
                    EndDate = new DateTime(2025, 5, 17, 17, 0, 0)
                },
                new Event
                {
                    Id = event2Id,
                    ClientId = 2,
                    Name = "Marketing Workshop",
                    Type = EventType.Corporate,
                    Description = "Hands-on workshop for marketing professionals.",
                    StartDate = new DateTime(2025, 6, 10, 9, 30, 0),
                    EndDate = new DateTime(2025, 6, 10, 16, 30, 0)
                }
            );
        }
    }
}
