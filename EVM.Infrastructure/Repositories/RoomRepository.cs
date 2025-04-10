using EVM.Application.Interfaces.Repositories;
using EVM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EVM.Infrastructure.Repositories
{
    public class RoomRepository(EventVenueManagerContext ctx) : RepositoryBase<Event>(ctx), IRoomRepository
    {
        public async Task<bool> IsRoomAvailable(int roomId, DateTime startDate, DateTime endDate)
        {
            return !await ctx.RoomReservations
                .AnyAsync(rr => rr.RoomId == roomId &&
                                ((startDate >= rr.Event.StartDate && startDate < rr.Event.EndDate) ||
                                 (endDate > rr.Event.StartDate && endDate <= rr.Event.EndDate) ||
                                 (startDate <= rr.Event.StartDate && endDate >= rr.Event.EndDate)));
        }
    }
}
