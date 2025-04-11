using EVM.Domain.Entities;

namespace EVM.Application.DTO
{
    public class CateringOptionDTO
    {
        public Guid Id { get; set; }
        public Guid EventId { get; set; }
        public int CateringId { get; set; }
        public int NumberOfPeople { get; set; }

        public CateringOptionDTO() { }

        public CateringOptionDTO(CateringOption co)
        {
            Id = co.Id;
            EventId = co.EventId;
            CateringId = co.CateringId;
            NumberOfPeople = co.NumberOfPeople;
        }
    }
}