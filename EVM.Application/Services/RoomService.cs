using EVM.Application.Interfaces.Services;
using EVM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVM.Application.Services
{
    public class RoomService : IRoomService
    {
        public Task<IEnumerable<Room>> GetAllRoomsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Room> GetRoomByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
