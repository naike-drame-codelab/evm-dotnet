namespace EVM.Application.DTO
{
    public class RoomReservationDTO
    {
        public Guid Id { get; set; }
        public int RoomId { get; set; }
        public int RoomCapacity { get; set; }
    }
}