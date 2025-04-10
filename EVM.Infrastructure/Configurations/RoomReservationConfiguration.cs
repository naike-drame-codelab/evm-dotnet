using EVM.Domain.Entities;
using EVM.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EVM.Infrastructure.Configurations
{
    public class RoomReservationConfiguration : IEntityTypeConfiguration<RoomReservation>
    {
        public void Configure(EntityTypeBuilder<RoomReservation> builder)
        {
            EnumToStringConverter<PaymentStatus> converter = new EnumToStringConverter<PaymentStatus>();

            builder.HasKey(rr => rr.Id); 

            builder.Property(rr => rr.PaymentStatus).HasDefaultValue(PaymentStatus.Pending);
            builder.Property(rr => rr.PaymentStatus).HasConversion(converter);

            builder.HasOne(rr => rr.Event)
                   .WithMany(e => e.RoomReservations)
                   .HasForeignKey(rr => rr.EventId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(rr => rr.Room)
                   .WithMany(r => r.Reservations)
                   .HasForeignKey(rr => rr.RoomId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(rr => new { rr.EventId, rr.RoomId }).IsUnique();

            var reservation1Id = Guid.Parse("01234567-89ab-cdef-0123-456789abcdef");
            var reservation2Id = Guid.Parse("98765432-10fe-dcba-9876-543210fedcba");
            var event1Id = Guid.Parse("a1b2c3d4-e5f6-7890-1234-567890abcdef");
            var event2Id = Guid.Parse("fedcba98-7654-3210-fedc-ba9876543210");

            builder.HasData(
                new RoomReservation { Id = reservation1Id, PaymentStatus = PaymentStatus.Completed, EventId = event1Id, RoomId = 1 },
                new RoomReservation { Id = reservation2Id, EventId = event2Id, RoomId = 2 }
            );
        }
    }
}
