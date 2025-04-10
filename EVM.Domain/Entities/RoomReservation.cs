using System.ComponentModel.DataAnnotations.Schema;
using EVM.Domain.Enums;

namespace EVM.Domain.Entities
{
    // junction table for many-to-many relationship between Event and Room
    public class RoomReservation
    {
        public Guid Id { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
       
        public Guid EventId { get; set; }
        public Event? Event { get; set; }
        
        public int RoomId { get; set; }
        public Room? Room { get; set; }

    }
}