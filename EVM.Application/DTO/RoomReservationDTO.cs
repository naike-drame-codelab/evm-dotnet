using EVM.Domain.Enums;

namespace EVM.Application.DTO
{
    public class RoomReservationDTO
    {
        public Guid Id { get; set; }
        public int RoomId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}