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
    public class EventLogConfiguration : IEntityTypeConfiguration<EventLog>
    {
        public void Configure(EntityTypeBuilder<EventLog> builder)
        {
            EnumToStringConverter<EventType> converter = new EnumToStringConverter<EventType>();

            builder.HasKey(el => el.Id);

            builder.Property(el => el.EventType)
                .HasConversion(converter);

            builder.Property(el => el.EventType)
                .HasMaxLength(100);

            builder.Property(el => el.Source)
                .HasMaxLength(100);


            builder.Property(el => el.DetailsJson)
                .HasColumnType("TEXT"); 

            builder.HasOne(el => el.Client)
                .WithMany() 
                .HasForeignKey(el => el.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(el => el.Timestamp)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
