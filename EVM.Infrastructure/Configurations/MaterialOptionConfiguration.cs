﻿using EVM.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVM.Infrastructure.Configurations
{
    public class MaterialOptionConfiguration : IEntityTypeConfiguration<MaterialOption>
    {
        public void Configure(EntityTypeBuilder<MaterialOption> builder)
        {
            builder.HasKey(mo => mo.Id); // Explicit primary key

            builder.HasOne(mo => mo.Event)
                   .WithMany(e => e.MaterialOptions)
                   .HasForeignKey(mo => mo.EventId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(mo => mo.Material)
                   .WithMany(m => m.Options)
                   .HasForeignKey(mo => mo.MaterialId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(mo => new { mo.EventId, mo.MaterialId }).IsUnique();

            var event1Id = Guid.Parse("a1b2c3d4-e5f6-7890-1234-567890abcdef");
            var event2Id = Guid.Parse("fedcba98-7654-3210-fedc-ba9876543210");
            var mo1Id = Guid.Parse("12345678-90ab-cdef-1234-567890abcdef");
            var mo2Id = Guid.Parse("abcdef12-3456-7890-abcd-ef1234567890");

            builder.HasData(
                new MaterialOption { Id = mo1Id, EventId = event1Id, MaterialId = 1, Quantity = 2 },
                new MaterialOption { Id = mo2Id, EventId = event2Id, MaterialId = 3, Quantity = 1 } 
            );
        }
    }
}
