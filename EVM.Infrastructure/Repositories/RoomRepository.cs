using EVM.Application.Interfaces.Repositories;
using EVM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EVM.Infrastructure.Repositories
{
    public class RoomRepository(EventVenueManagerContext ctx) : RepositoryBase<Room>(ctx), IRoomRepository
    {
        public async Task<bool> IsRoomAvailable(int roomId, DateTime startDate, DateTime endDate)
        {
            return !await ctx.RoomReservations
                .AnyAsync(rr => rr.RoomId == roomId &&
                                ((startDate >= rr.Event.StartDate && startDate < rr.Event.EndDate) ||
                                 (endDate > rr.Event.StartDate && endDate <= rr.Event.EndDate) ||
                                 (startDate <= rr.Event.StartDate && endDate >= rr.Event.EndDate)));
        }

        public async Task UpdateRoomAvailability(int roomId, DateTime startDate, DateTime endDate, bool isAvailable)
        {
            Room? room = await ctx.Rooms.Include(r => r.Reservations).FirstOrDefaultAsync(r => r.Id == roomId);
            if (room != null)
            {
                if (isAvailable)
                {
                    bool hasActiveReservations = room.Reservations?.Any(rr =>
                        rr.Event.StartDate < endDate
                        && rr.Event.EndDate > startDate) ?? false;

                    room.IsAvailable = !hasActiveReservations;
                }
                else
                {
                    room.IsAvailable = false;
                }

                await ctx.SaveChangesAsync();
            }
        }

    }
}
