
using EVM.Domain.Entities;

namespace EVM.Application.Interfaces.Repositories
{
    public interface IRoomRepository : IRepositoryBase<Room>
    {
        // Define methods related to room management here
        Task<bool> IsRoomAvailable(int roomId, DateTime startDate, DateTime endDate);
        Task UpdateRoomAvailability(int roomId, DateTime startDate, DateTime endDate, bool isAvailable);
    }
 
}