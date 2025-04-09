using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVM.Domain.Entities;
using EVM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EVM.Infrastructure
{
    public class EventVenueManagerContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Catering> Caterings { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<RoomReservation> RoomReservations { get; set; }
        public DbSet<MaterialOption> MaterialOptions { get; set; }
        public DbSet<CateringOption> CateringOptions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<EventLog> EventLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AdminConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            modelBuilder.ApplyConfiguration(new MaterialConfiguration());
            modelBuilder.ApplyConfiguration(new CateringConfiguration());
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new RoomReservationConfiguration());
            modelBuilder.ApplyConfiguration(new MaterialOptionConfiguration());
            modelBuilder.ApplyConfiguration(new CateringOptionConfiguration());
            modelBuilder.ApplyConfiguration(new TicketConfiguration());
            modelBuilder.ApplyConfiguration(new EventLogConfiguration());
        }
    }
}
