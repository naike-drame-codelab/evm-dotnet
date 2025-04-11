using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVM.Domain.Entities;
using EVM.Domain.Enums;

namespace EVM.Application.DTO
{
    public record EventDetailsDTO(Event e)
    {
        [Required] public Guid Id { get; set; } = e.Id;
        [Required] public string Name { get; set; } = e.Name;
        [Required] public DateTime StartDate { get; set; } = e.StartDate;
        [Required] public DateTime EndDate { get; set; } = e.EndDate;
        [Required] public EventType Type { get; set; } = e.Type;
        [Required] public EventStatus Status { get; set; } = e.Status;
        [Required] public string Description { get; set; } = e.Description;
        public string? ImageUrl { get; set; } = e.ImageUrl;
        public List<RoomReservationDTO> RoomReservations { get; set; } = e.RoomReservations.Select(rr => new RoomReservationDTO(rr)).ToList();
        public List<MaterialOptionDTO>? MaterialOptions { get; set; } = e.MaterialOptions?.Select(mo => new MaterialOptionDTO(mo)).ToList();
        public List<CateringOptionDTO>? CateringOptions { get; set; } = e.CateringOptions?.Select(co => new CateringOptionDTO(co)).ToList();
    }
}
