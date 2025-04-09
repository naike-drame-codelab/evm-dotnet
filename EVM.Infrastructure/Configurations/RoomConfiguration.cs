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
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Name).IsRequired().HasMaxLength(100);
            builder.Property(r => r.PricePerHour).HasColumnType("decimal(18, 2)");

            builder.HasMany(r => r.Reservations)
                   .WithOne(rr => rr.Room)
                   .HasForeignKey(rr => rr.RoomId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Room
                {
                    Id = 1,
                    Name = "Grand Ballroom",
                    Description = "Our largest and most elegant space, perfect for weddings, galas, and large conferences. Features high ceilings, a stage, and ample dance floor.",
                    Capacity = 200,
                    PricePerHour = 150.00m,
                    IsAvailable = true
                },
                new Room
                {
                    Id = 2,
                    Name = "Conference Room A",
                    Description = "A well-equipped conference room ideal for meetings, workshops, and presentations. Includes built-in AV equipment and comfortable seating.",
                    Capacity = 50,
                    PricePerHour = 75.00m,
                    IsAvailable = true
                },
                new Room
                {
                    Id = 3,
                    Name = "Meeting Room 1",
                    Description = "A smaller, more intimate meeting room suitable for team discussions, interviews, and small group sessions. Offers a quiet and focused environment.",
                    Capacity = 20,
                    PricePerHour = 40.00m,
                    IsAvailable = true
                },
                new Room
                {
                    Id = 4,
                    Name = "Executive Suite",
                    Description = "A premium suite offering a sophisticated setting for high-level meetings and VIP events. Includes a private lounge area and dedicated amenities.",
                    Capacity = 30,
                    PricePerHour = 120.00m,
                    IsAvailable = false
                },
                new Room
                {
                    Id = 5,
                    Name = "Training Room B",
                    Description = "A flexible training room that can be configured in various layouts. Equipped with whiteboards and projector screens, perfect for workshops and training sessions.",
                    Capacity = 60,
                    PricePerHour = 85.00m,
                    IsAvailable = true
                }
            );
        }
    }
}
