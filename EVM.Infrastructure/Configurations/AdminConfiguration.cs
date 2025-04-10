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

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Username).HasMaxLength(50);
            builder.Property(a => a.Password).HasMaxLength(100);
            builder.Property(a => a.Role).HasConversion(converter);
            builder.Property(a => a.Role).HasDefaultValue(Role.Admin);

            builder.HasData(
               new Admin { Id = 1, Username = "guildmaster", Password = "1234", Email = "admin@evm.net" } // TODO hash passwords!
            );
        }
    }
}
