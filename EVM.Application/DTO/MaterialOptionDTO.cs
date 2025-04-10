namespace EVM.Application.DTO
{
    public class MaterialOptionDTO
    {
        public int MaterialId { get; set; }
        public Guid EventId { get; set; }
        public int Quantity { get; set; }
        public int Id { get; internal set; }
    }
}