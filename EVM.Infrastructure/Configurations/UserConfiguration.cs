using EVM.Domain.Entities;
using EVM.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EVM.Infrastructure.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            EnumToStringConverter<Role> converter = new EnumToStringConverter<Role>();

            builder.ToTable("Users");

            builder.Property(u => u.LastName).HasMaxLength(100);
            builder.Property(u => u.FirstName).HasMaxLength(100);
            builder.Property(u => u.Email).HasMaxLength(100);
            builder.Property(u => u.Password).HasMaxLength(50);
            builder.Property(u => u.PhoneNumber).HasMaxLength(100);
            builder.Property(u => u.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(u => u.Role).HasConversion(converter);
        }
    }
}
