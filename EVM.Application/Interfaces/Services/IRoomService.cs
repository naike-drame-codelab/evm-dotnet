using EVM.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVM.Application.Interfaces.Services
{
    public interface IRoomService
    {
        // Define methods related to room management here
        Task<IEnumerable<Room>> GetAllRoomsAsync();
        Task<Room> GetRoomByIdAsync(int id);
        Task<bool> IsRoomAvailableAsync(int roomId, DateTime startDate, DateTime endDate);

    }
}
