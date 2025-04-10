using EVM.Application.DTO;
using EVM.Domain.Entities;

namespace EVM.Application.Interfaces.Services
{
    public interface IEventService
    {
        Task<Event> CreateEvent(EventCreateDTO dto);
        Task<Event> DeleteEvent(Guid id);
        Task<Event> GetEventById(Guid id);
        Task<EventDetailsDTO> GetEventDetailsAsync(Guid eventId);
        Task<IEnumerable<Event>> GetEvents(bool includeDetails = false);
        Task<IEnumerable<Event>> GetEventsWithRoomReservations();
        Task<Event> UpdateEvent(Guid id, Event updatedEvent);
    }
}