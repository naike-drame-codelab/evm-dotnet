﻿using System.Security.Cryptography;
using System.Text;
using EVM.Domain.Entities;
using EVM.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EVM.Infrastructure.Configurations
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            EnumToStringConverter<Role> converter = new EnumToStringConverter<Role>();

            Guid guid = new Guid("0c59677d-5989-43df-a9f8-5c04baf73c4b");

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Username).HasMaxLength(50);
            builder.Property(a => a.Password).HasMaxLength(255);
            builder.Property(a => a.Role).HasConversion(converter);
            builder.Property(a => a.Role).HasDefaultValue(Role.Admin);

            builder.HasData(
               new Admin
               {
                   Id = 1,
                   Username = "guildmaster",
                   Salt = guid,
                   Email = "admin@evm.net",
                   Password = Encoding.UTF8.GetString(SHA512.HashData(Encoding.UTF8.GetBytes("1234" + guid))),
               } 
            );
        }
    }
}
