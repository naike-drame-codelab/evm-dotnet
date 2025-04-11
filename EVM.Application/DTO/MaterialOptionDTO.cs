using System.Text.Json.Serialization;
using EVM.Domain.Entities;

namespace EVM.Application.DTO
{
    public class MaterialOptionDTO
    {
        public Guid Id { get; set; }
        public Guid EventId { get; set; }
        public int MaterialId { get; set; }
        public int Quantity { get; set; }

        // Parameterless constructor for deserialization
        public MaterialOptionDTO() { }

        // Constructor for mapping from MaterialOption entity
        public MaterialOptionDTO(MaterialOption mo)
        {
            Id = mo.Id;
            EventId = mo.EventId;
            MaterialId = mo.MaterialId;
            Quantity = mo.Quantity;
        }
    }
}