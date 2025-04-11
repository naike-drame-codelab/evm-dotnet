using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        public ICollection<RoomReservationDTO> RoomReservations { get; set; } = e.RoomReservations.Select(rr => new RoomReservationDTO(rr)).ToList();
        public ICollection<MaterialOptionDTO>? MaterialOptions { get; set; } = e.MaterialOptions?.Select(mo => new MaterialOptionDTO(mo)).ToList();
        public ICollection<CateringOptionDTO>? CateringOptions { get; set; } = e.CateringOptions?.Select(co => new CateringOptionDTO(co)).ToList();
        public ICollection<Ticket>? Tickets { get; set; } = e.Tickets;
    }
}
