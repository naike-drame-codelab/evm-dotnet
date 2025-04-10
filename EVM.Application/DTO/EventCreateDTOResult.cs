using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVM.Domain.Entities;
using EVM.Domain.Enums;

namespace EVM.Application.DTO
{
    public record class EventCreateDTOResult(Event e)
    {
        public Guid Id { get; set; } = e.Id;
        public string Name { get; set; } = e.Name;
        public string? ImageUrl { get; set; } = e.ImageUrl;
        public int ClientId { get; set; } = e.ClientId;
        public EventType Type { get; set; } = e.Type;
        public EventStatus Status { get; set; } = e.Status;
        public string Description { get; set; } = e.Description;
        public DateTime StartDate { get; set; } = e.StartDate;
        public DateTime EndDate { get; set; } = e.EndDate;
        public ICollection<RoomReservation>? RoomReservations { get; set; } = e.RoomReservations;
        public ICollection<MaterialOption>? MaterialOptions { get; set; } = e.MaterialOptions;
        public ICollection<CateringOption>? CateringOptions { get; set; } = e.CateringOptions;
        public ICollection<Ticket>? Tickets { get; set; } = e.Tickets;
    }
}
