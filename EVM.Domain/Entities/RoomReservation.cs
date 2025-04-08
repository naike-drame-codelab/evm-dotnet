using System.ComponentModel.DataAnnotations.Schema;
using EVM.Domain.Enums;

namespace EVM.Domain.Entities
{
    // junction table for many-to-many relationship between Event and Room
    public class RoomReservation
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public DateTime ReservationStartTime { get; set; }
        public DateTime ReservationEndTime { get; set; }
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;

        [ForeignKey("Event")]
        public int EventId { get; set; }
        public required Event Event { get; set; }

        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public required Room Room { get; set; }

    }
}