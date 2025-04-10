namespace EVM.Application.DTO
{
    public class CateringOptionDTO
    {
        public int CateringId { get; set; }
        public Guid EventId { get; set; }
        public int NumberOfPeople { get; set; }
        public int Id { get; internal set; }
    }
}