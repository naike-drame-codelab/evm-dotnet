using EVM.Domain.Entities;
using EVM.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EVM.Infrastructure.Configurations
{
    internal class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            EnumToStringConverter<Role> converter = new EnumToStringConverter<Role>();

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).HasMaxLength(100);
            builder.Property(c => c.Email).HasMaxLength(255);
            builder.Property(c => c.Password).HasMaxLength(50);
            builder.Property(c => c.PhoneNumber).HasMaxLength(50);
            builder.Property(c => c.Role).HasConversion(converter);
            builder.Property(c => c.Role).HasDefaultValue(Role.Client);

            builder.HasMany(c => c.Events)
                .WithOne(e => e.Client)
                .HasForeignKey(e => e.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
            new Client
            {
                Id = 1,
                Name = "EventPro Corp",
                Email = "info@eventpro.com",
                Password = "epropass",
                PhoneNumber = "123-456-7890",
            },
            new Client
            {
                Id = 2,
                Name = "Global Gatherings",
                Email = "contact@globalgatherings.net",
                Password = "ggpass",
                PhoneNumber = "987-654-3210",
            },
            new Client
            {
                Id = 3,
                Name = "Event Planner Alice",
                Email = "alice.planner@events.net",
                Password = "eventpass",
                PhoneNumber = "555-123-4567",
            }
        );
        }
    }
}
