using System.Security.Cryptography;
using System.Text;
using System;
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

            Guid guid1 = new Guid("67F51696-864A-4B82-BA6E-8D2C434532A2");
            Guid guid2 = new Guid("045BB8B9-60F9-4D06-8B12-E46A912883DD");
            Guid guid3 = new Guid("A7D1EC62-1ACD-4F89-9E48-2DE2975F77EE");


            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).HasMaxLength(100);
            builder.Property(c => c.Email).HasMaxLength(255);
            builder.Property(c => c.Password).HasMaxLength(255);
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
                Salt = guid1,
                Password = Encoding.UTF8.GetString(SHA512.HashData(Encoding.UTF8.GetBytes("epropass" + guid1))),
                PhoneNumber = "123-456-7890",
            },
            new Client
            {
                Id = 2,
                Name = "Global Gatherings",
                Email = "contact@globalgatherings.net",
                Salt = guid2,
                Password = Encoding.UTF8.GetString(SHA512.HashData(Encoding.UTF8.GetBytes("ggpass" + guid2))),
                PhoneNumber = "987-654-3210",
            },
            new Client
            {
                Id = 3,
                Name = "Event Planner Alice",
                Email = "alice.planner@events.net",
                Salt = guid3,
                Password = Encoding.UTF8.GetString(SHA512.HashData(Encoding.UTF8.GetBytes("epass" + guid3))),
                PhoneNumber = "555-123-4567",
            }
        );
        }
    }
}
