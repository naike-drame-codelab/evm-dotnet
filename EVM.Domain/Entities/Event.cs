using EVM.Domain.Enums;

namespace EVM.Domain.Entities
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? ImageUrl { get; set; } = null!;
        public EventType Type { get; set; }
        public EventStatus Status { get; set; }
        public string Description { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        public required ICollection<RoomReservation> RoomReservations { get; set; } 
        public ICollection<MaterialOption>? MaterialOptions { get; set; }
        public ICollection<CateringOption>? CateringOptions { get; set; }
        public ICollection<Ticket>? Tickets { get; set; }

        public int ClientId { get; set; }
        public Client? Client { get; set; }

        public decimal CalculateEstimatedCost()
        {
            decimal roomCost = RoomReservations?.Sum(r =>
            {
                if (r.Room == null) return 0;

                double hours = (EndDate - StartDate).TotalHours;

                return (decimal)hours * r.Room.PricePerHour;
            }) ?? 0;

            decimal materialCost = MaterialOptions?.Sum(m => m.Quantity * (m.Material?.PricePerUnit ?? 0)) ?? 0;

            decimal cateringCost = CateringOptions?.Sum(c => c.TotalPrice) ?? 0;

            return roomCost + materialCost + cateringCost;
        }
    }
}