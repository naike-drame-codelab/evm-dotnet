using EVM.Domain.Enums;

namespace EVM.Domain.Entities
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? ImageUrl { get; set; } = null!;
        public EventType Type { get; set; }
        public string Description { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        public ICollection<RoomReservation>? RoomReservations { get; set; }
        public ICollection<MaterialOption>? MaterialOptions { get; set; }
        public ICollection<CateringOption>? CateringOptions { get; set; }
        public ICollection<Ticket>? Tickets { get; set; }

        public int ClientId { get; set; }
        public Client? Client { get; set; }
    }
}