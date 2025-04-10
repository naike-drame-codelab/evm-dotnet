using System.ComponentModel.DataAnnotations;
using EVM.Domain.Enums;

namespace EVM.Application.DTO
{
    public record EventCreateDTO
    {
        [Required] public string Name { get; set; } = null!;
        [Required] public DateTime StartDate { get; set; }
        [Required] public DateTime EndDate { get; set; }
        [Required] public EventType Type { get; set; }
        [Required] public EventStatus Status { get; set; }
        [Required] public string Description { get; set; } = null!;
        public string? ImageUrl { get; set; }
        [Required] public List<RoomReservationDTO> RoomReservations { get; set; } = new();
        public List<MaterialOptionDTO>? MaterialOptions { get; set; }
        public List<CateringOptionDTO>? CateringOptions { get; set; }
        [Required] public int ClientId { get; set; } // Changed to public set
    }


}
