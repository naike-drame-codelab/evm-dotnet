using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVM.Domain.Enums;

namespace EVM.Application.DTO
{
    public record EventDetailsDTO
    {
        [Required] public Guid Id { get; set; }
        [Required] public string Name { get; set; } = null!;
        [Required] public DateTime StartDate { get; set; }
        [Required] public DateTime EndDate { get; set; }
        [Required] public EventType Type { get; set; }
        [Required] public EventStatus Status { get; set; }
        [Required] public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public List<RoomReservationDTO>? RoomReservations { get; set; }
        public List<MaterialOptionDTO>? MaterialOptions { get; set; }
        public List<CateringOptionDTO>? CateringOptions { get; set; }
    }
}
