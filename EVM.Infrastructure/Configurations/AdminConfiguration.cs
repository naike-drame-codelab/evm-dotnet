using EVM.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVM.Domain.Enums;

namespace EVM.Infrastructure.Configurations
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Username).HasMaxLength(50);
            builder.Property(a => a.Password).HasMaxLength(100);
            builder.Property(c => c.Role).HasDefaultValue(Role.Admin);

            builder.HasData(
               new Admin { Id = 1, Username = "guildmaster", Password = "1234" } // TODO hash passwords!
            );
        }
    }
}
