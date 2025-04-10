using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVM.Domain.Entities;

namespace EVM.Application.Interfaces.Repositories
{
    public interface IEventRepository : IRepositoryBase<Event>
    {
        Task<IEnumerable<Event>> FindEventsWithRoomReservationsAsync();
        Task<Event?> FindEventWithDetailsByIdAsync(Guid eventId);
    }
}
