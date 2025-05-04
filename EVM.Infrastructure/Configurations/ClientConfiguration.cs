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
            Guid guid4 = new Guid("92AC876F-EE41-47DD-9C8B-CA0D38BA3974");
            Guid guid5 = new Guid("E3B55037-3257-421D-9C8C-8276E6A0BCA0");
            Guid guid6 = new Guid("CFE18D0E-3DBB-4BB7-A940-0941BDEA2D6D");
            Guid guid7 = new Guid("252DAB5A-4508-4750-932E-C558B5BB03CA");
            Guid guid8 = new Guid("CCED3ADA-98EA-4CB6-B18C-085CCECA338C");


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
            },
            new Client
            {
                Id = 4,
                Name = "XYZ Corporation",
                Email = "john@xyz.net",
                Salt = guid4,
                Password = Encoding.UTF8.GetString(SHA512.HashData(Encoding.UTF8.GetBytes("1234" + guid4))),
                PhoneNumber = "585-123-4567",
            },
            new Client
            {
                Id = 5,
                Name = "Emily Johnson",
                Email = "emily@ejplanner.org",
                Salt = guid5,
                Password = Encoding.UTF8.GetString(SHA512.HashData(Encoding.UTF8.GetBytes("1234" + guid5))),
                PhoneNumber = "585-123-4567",
            },
            new Client
            {
                Id = 6,
                Name = "Tech Innovations LLC",
                Email = "mchen@tech.net",
                Salt = guid6,
                Password = Encoding.UTF8.GetString(SHA512.HashData(Encoding.UTF8.GetBytes("1234" + guid6))),
                PhoneNumber = "585-123-4567",
            },
             new Client
            {
                Id = 7,
                Name = "Media Inc.",
                Email = "mchen@tech.net",
                Salt = guid7,
                Password = Encoding.UTF8.GetString(SHA512.HashData(Encoding.UTF8.GetBytes("1234" + guid7))),
                PhoneNumber = "585-123-4567",
            }, 
             new Client
            {
                Id = 8,
                Name = "Global Finance Group",
                Email = "mchen@tech.net",
                Salt = guid8,
                Password = Encoding.UTF8.GetString(SHA512.HashData(Encoding.UTF8.GetBytes("1234" + guid8))),
                PhoneNumber = "585-123-4567",
            }
        );
        }
    }
}
