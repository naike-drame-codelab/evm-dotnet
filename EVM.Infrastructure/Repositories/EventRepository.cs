using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVM.Application.Interfaces.Repositories;
using EVM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EVM.Infrastructure.Repositories
{
    public class EventRepository(EventVenueManagerContext ctx) : RepositoryBase<Event>(ctx), IEventRepository
    {
        public async Task<IEnumerable<Event>> FindEventsWithRoomReservationsAsync()
        {
            return await ctx.Events
                 .Where(e => e.RoomReservations != null)
                 .Include(e => e.RoomReservations)
                 .ToListAsync();
        }

        public async Task<Event?> FindEventWithDetailsByIdAsync(Guid eventId)
        {
            return await ctx.Events
                .Include(e => e.RoomReservations!)
                    .ThenInclude(rr => rr.Room)
                .Include(e => e.MaterialOptions!)
                    .ThenInclude(mo => mo.Material)
                .Include(e => e.CateringOptions!)
                    .ThenInclude(co => co.Catering)
                .FirstOrDefaultAsync(e => e.Id == eventId)
                ?? throw new KeyNotFoundException($"Event with ID {eventId} was not found.");
        }
    }
}
