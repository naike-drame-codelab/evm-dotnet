using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Transactions;
using EVM.Application.DTO;
using EVM.Application.Interfaces.Repositories;
using EVM.Application.Interfaces.Services;
using EVM.Domain.Entities;
using EVM.Domain.Enums;

namespace EVM.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository eventRepository;
        private readonly IRoomRepository roomRepository;
        private readonly IClientRepository clientRepository;
        public EventService(IEventRepository eventRepository, IRoomRepository roomRepository, IClientRepository clientRepository)
        {
            this.eventRepository = eventRepository;
            this.roomRepository = roomRepository;
            this.clientRepository = clientRepository;
        }
    
        public async Task<IEnumerable<Event>> GetEvents(bool includeDetails = false)
        {
            if (includeDetails)
            {
                return await eventRepository.FindEventsWithRoomReservationsAsync();
            }

            return await eventRepository.FindAsync();
        }

        public async Task<IEnumerable<Event>> GetEventsWithRoomReservations()
        {
            return await eventRepository.FindWhereAsync(e => e.RoomReservations != null && e.RoomReservations.Any());
        }

        public async Task<Event> GetEventById(Guid id)
        {
            return await eventRepository.FindOneAsync(id) ?? throw new KeyNotFoundException($"Event with id {id} not found.");
        }

        public async Task<EventDetailsDTO> GetEventDetailsAsync(Guid eventId)
        {
            Event? e = await eventRepository.FindEventWithDetailsByIdAsync(eventId);

            if (e == null)
            {
                throw new KeyNotFoundException($"Event with id {eventId} not found.");
            }

            return new EventDetailsDTO(e);
        }

        public async Task<Event> CreateEvent(EventCreateDTO dto)
        {
            if (await eventRepository.AnyAsync(e => e.Name == dto.Name))
            {
                throw new InvalidOperationException($"Event with name {dto.Name} already exists.");
            }

            if (dto.RoomReservations == null || dto.RoomReservations.Count == 0)
            {
                throw new InvalidOperationException("At least one room reservation is required to create an event.");
            }

            if (!await clientRepository.AnyAsync(c => c.Id == dto.ClientId))
            {
                throw new InvalidOperationException($"Client with ID {dto.ClientId} does not exist.");
            }

            using TransactionScope scope = new(TransactionScopeAsyncFlowOption.Enabled);

            Guid eventId = Guid.NewGuid();

            foreach (int roomId in dto.RoomReservations)
            {
                bool isRoomAvailable = await roomRepository.IsRoomAvailable(roomId, dto.StartDate, dto.EndDate);
                if (!isRoomAvailable)
                {
                    throw new InvalidOperationException($"Room {roomId} is not available for the selected dates.");
                }

            }

            Event e = await eventRepository.AddAsync(new Event
            {
                Id = eventId,
                Name = dto.Name,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Type = dto.Type,
                Status = dto.Status,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                ClientId = dto.ClientId,
                RoomReservations = dto.RoomReservations.Select(rId => new RoomReservation
                {
                    RoomId = rId
                }).ToList(),
                MaterialOptions = dto.MaterialOptions?.Select(mo => new MaterialOption
                {
                    Id = Guid.NewGuid(),
                    MaterialId = mo.MaterialId,
                    Quantity = mo.Quantity,
                }).ToList(),
                CateringOptions = dto.CateringOptions?.Select(co => new CateringOption
                {
                    Id = Guid.NewGuid(),
                    CateringId = co.CateringId, 
                    NumberOfPeople = co.NumberOfPeople,
                }).ToList()
            });
            
            scope.Complete();
            
            return e;
        }

        public async Task<Event> UpdateEvent(Guid id, Event updatedEvent)
        {
            Event existingEvent = await eventRepository.FindEventWithDetailsByIdAsync(id)
                ?? throw new KeyNotFoundException($"Event with id {id} not found.");

            // Update event properties
            existingEvent.Name = updatedEvent.Name;
            existingEvent.StartDate = updatedEvent.StartDate;
            existingEvent.EndDate = updatedEvent.EndDate;
            existingEvent.Type = updatedEvent.Type;
            existingEvent.Description = updatedEvent.Description;
            existingEvent.ImageUrl = updatedEvent.ImageUrl;

            existingEvent.RoomReservations = updatedEvent.RoomReservations;

            existingEvent.MaterialOptions = updatedEvent.MaterialOptions;

            existingEvent.CateringOptions = updatedEvent.CateringOptions;

            return await eventRepository.UpdateAsync(existingEvent);
        }

        public async Task<Event> DeleteEvent(Guid id)
        {
            Event existingEvent = await eventRepository.FindEventWithDetailsByIdAsync(id)
                ?? throw new KeyNotFoundException($"Event with id {id} not found.");

            existingEvent.RoomReservations?.Clear();
            existingEvent.MaterialOptions?.Clear();
            existingEvent.CateringOptions?.Clear();

            return await eventRepository.RemoveAsync(existingEvent);
        }

        public async Task ValidateEventDatesAsync(DateTime startDate, DateTime endDate)
        {
            if (startDate >= endDate)
            {
                throw new InvalidOperationException("StartDate must be earlier than EndDate.");
            }

            if (startDate < DateTime.UtcNow)
            {
                throw new InvalidOperationException("StartDate must be in the future.");
            }

            List<Event> overlappingEvents = await eventRepository.FindWhereAsync(e =>
                e.StartDate < endDate && e.EndDate > startDate);

            if (overlappingEvents.Any())
            {
                throw new InvalidOperationException("The selected dates overlap with another event.");
            }
        }

        public async Task<decimal> CalculateEstimatedCostAsync(Guid eventId)
        {
            // Fetch the event with all necessary details
            Event? e = await eventRepository.FindEventWithDetailsByIdAsync(eventId);

            if (e == null)
            {
                throw new KeyNotFoundException($"Event with id {eventId} not found.");
            }

            decimal roomCost = e.RoomReservations?.Sum(r =>
            {
                if (r.Room == null) return 0;

                double hours = (e.EndDate - e.StartDate).TotalHours;
                return (decimal)hours * r.Room.PricePerHour;
            }) ?? 0;

            decimal materialCost = e.MaterialOptions?.Sum(m =>
                m.Quantity * (m.Material?.PricePerUnit ?? 0)) ?? 0;

            decimal cateringCost = e.CateringOptions?.Sum(c => c.NumberOfPeople * (c.Catering?.PricePerPerson ?? 0)) ?? 0;

            return roomCost + materialCost + cateringCost;
        }

        public Task<bool> IsRoomAvailable(int roomId, DateTime startDate, DateTime endDate)
        {
            return roomRepository.IsRoomAvailable(roomId, startDate, endDate);
        }

        
    }
}
