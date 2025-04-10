using System.ComponentModel.DataAnnotations;
using System.Transactions;
using EVM.Application.DTO;
using EVM.Application.Interfaces.Repositories;
using EVM.Application.Interfaces.Services;
using EVM.Domain.Entities;
using EVM.Domain.Enums;

namespace EVM.Application.Services
{
    public class EventService(IEventRepository eventRepository) : IEventService
    {
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

            return new EventDetailsDTO
            {
                Id = e.Id,
                Name = e.Name,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                Type = e.Type,
                Status = e.Status,
                Description = e.Description,
                ImageUrl = e.ImageUrl ?? "",
                RoomReservations = e.RoomReservations?.Select(rr => new RoomReservationDTO
                {
                    Id = rr.Id,
                    RoomCapacity = rr.Room?.Capacity ?? 0
                }).ToList() ?? new List<RoomReservationDTO>(),
                MaterialOptions = e.MaterialOptions?.Select(mo => new MaterialOptionDTO
                {
                    Id = mo.Id,
                    Quantity = mo.Quantity
                }).ToList() ?? new List<MaterialOptionDTO>(),
                CateringOptions = e.CateringOptions?.Select(co => new CateringOptionDTO
                {
                    Id = co.Id,
                    NumberOfPeople = co.NumberOfPeople
                }).ToList() ?? new List<CateringOptionDTO>()
            };
        }


        public async Task<Event> CreateEvent(EventCreateDTO dto)
        {
            if (await eventRepository.AnyAsync(e => e.Name == dto.Name))
            {
                throw new InvalidOperationException($"Event with name {dto.Name} already exists.");
            }

            using TransactionScope scope = new();

            Event e = await eventRepository.AddAsync(new Event
            {
                Name = dto.Name,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Type = dto.Type,
                Status = dto.Status,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                RoomReservations = dto.RoomReservations?.Select(rr => new RoomReservation
                {
                    RoomId = rr.RoomId, 
                    EventId = Guid.NewGuid()
                }).ToList(),
                MaterialOptions = dto.MaterialOptions?.Select(mo => new MaterialOption
                {
                    MaterialId = mo.MaterialId, // Assuming MaterialId is mapped from MaterialOptionDTO.Id
                    Quantity = mo.Quantity
                }).ToList(),
                CateringOptions = dto.CateringOptions?.Select(co => new CateringOption
                {
                    CateringId = co.Id, // Assuming CateringId is mapped from CateringOptionDTO.Id
                    NumberOfPeople = co.NumberOfPeople
                }).ToList()
            });

            scope.Complete();

            await eventRepository.AddAsync(e);
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

    }
}
