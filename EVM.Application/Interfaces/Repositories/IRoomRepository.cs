
namespace EVM.Application.Interfaces.Repositories
{
    public interface IRoomRepository
    {
        Task<bool> IsRoomAvailable(int roomId, DateTime startDate, DateTime endDate);
    }
}