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
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            EnumToStringConverter<Role> converter = new EnumToStringConverter<Role>();

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).HasMaxLength(50);
            builder.Property(a => a.Password).HasMaxLength(100);
            builder.Property(c => c.Role).HasConversion(converter);
            builder.Property(c => c.Role).HasDefaultValue(Role.Admin);

            builder.HasData(
               new Admin { Id = 1, Name = "guildmaster", Password = "1234" } // TODO hash passwords!
            );
        }
    }
}
