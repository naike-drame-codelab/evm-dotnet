
namespace EVM.Application.Interfaces.Repositories
{
    public interface IRoomRepository
    {
        Task<bool> IsRoomAvailable(int roomId, DateTime startDate, DateTime endDate);
        Task UpdateRoomAvailability(int roomId, DateTime startDate, DateTime endDate, bool isAvailable);

    }
}