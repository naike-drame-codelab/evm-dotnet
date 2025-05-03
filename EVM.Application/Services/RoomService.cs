using EVM.Application.Interfaces.Repositories;
using EVM.Application.Interfaces.Services;
using EVM.Domain.Entities;

public class RoomService(IRoomRepository roomRepository) : IRoomService
{
    public async Task<IEnumerable<Room>> GetAllRoomsAsync()
    {
        return await roomRepository.FindAsync();
    }

    public async Task<Room> GetRoomByIdAsync(int id)
    {
        return await roomRepository.FindOneAsync(id) ?? throw new KeyNotFoundException($"Room with ID {id} not found.");
    }

    public async Task<bool> IsRoomAvailableAsync(int roomId, DateTime startDate, DateTime endDate)
    {
        return await roomRepository.IsRoomAvailable(roomId, startDate, endDate);
    }
}
