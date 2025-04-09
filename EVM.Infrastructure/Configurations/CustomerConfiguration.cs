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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Username).HasMaxLength(100);
            builder.Property(c => c.Email).HasMaxLength(255);
            builder.Property(c => c.Role).HasDefaultValue(Role.Customer);

            builder.HasMany(c => c.Tickets)
                   .WithOne(t => t.Customer)
                   .HasForeignKey(t => t.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Customer { Id = 1, Username = "Alice Smith", Email = "alice.smith@example.com" },
                new Customer { Id = 2, Username = "Bob Johnson", Email = "bob.johnson@example.com" }
            );
        }
    }
}
