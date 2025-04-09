namespace EVM.Domain.Entities
{
    public class CateringOption
    {
        public int Id { get; set; }
        public int NumberOfPeople { get; set; }
        public decimal TotalPrice { get; set; }
        
        public Guid EventId { get; set; }
        public Event? Event { get; set; }
        
        public int CateringId { get; set; }
        public Catering? Catering { get; set; }
    }
}