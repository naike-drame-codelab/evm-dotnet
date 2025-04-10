namespace EVM.Domain.Entities
{
    public class CateringOption
    {
        public Guid Id { get; set; }
        public int NumberOfPeople { get; set; }
        
        public Guid EventId { get; set; }
        public Event? Event { get; set; }
        
        public int CateringId { get; set; }
        public Catering? Catering { get; set; }
    }
}