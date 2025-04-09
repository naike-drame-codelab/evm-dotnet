using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVM.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EVM.Domain.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EVM.Infrastructure.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            EnumToStringConverter<TicketType> converter = new EnumToStringConverter<TicketType>();
            
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Price).HasColumnType("decimal(18, 2)");
            builder.Property(t => t.IsUsed).HasDefaultValue(false);
            builder.Property(t => t.QuantitySold).HasDefaultValue(0);
            builder.Property(t => t.PurchaseDate).HasDefaultValueSql("GETDATE()");
            builder.Property(t => t.Type).HasConversion(converter);

            builder.HasOne(t => t.Event)
                   .WithMany(e => e.Tickets)
                   .HasForeignKey(t => t.EventId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.Customer)
                   .WithMany(c => c.Tickets)
                   .HasForeignKey(t => t.CustomerId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            // Unique index to prevent duplicate event-customer tickets
            builder.HasIndex(t => new { t.EventId, t.CustomerId }).IsUnique();

            var event1Id = Guid.Parse("a1b2c3d4-e5f6-7890-1234-567890abcdef");
            var event2Id = Guid.Parse("fedcba98-7654-3210-fedc-ba9876543210");
            var ticket1Id = Guid.Parse("EA81FC53-C9BE-43CE-9446-989068A647A7");
            var ticket2Id = Guid.Parse("689F906C-446A-4B85-A266-DC2591C15482");

            builder.HasData(
                new Ticket { Id = ticket1Id, EventId = event1Id, CustomerId = 1, Price = 100.00m, Type = TicketType.Regular, QuantitySold = 2 },
                new Ticket { Id = ticket2Id, EventId = event2Id, CustomerId = 2, Price = 50.00m, Type = TicketType.VIP, QuantitySold = 1 }
            );
        }
    }
}
