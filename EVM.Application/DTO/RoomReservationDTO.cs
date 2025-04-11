using EVM.Domain.Entities;
using EVM.Domain.Enums;

namespace EVM.Application.DTO
{
    public class RoomReservationDTO(RoomReservation rr)
    {
        public Guid Id { get; set; } = rr.Id;
        public int RoomId { get; set; } = rr.RoomId;
        public PaymentStatus PaymentStatus { get; set; } = rr.PaymentStatus;
    }
}