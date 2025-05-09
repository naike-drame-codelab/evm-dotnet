﻿namespace EVM.Domain.Entities
{
    public class MaterialOption
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        
        public int MaterialId { get; set; }
        public Material? Material { get; set; }

        public Guid EventId { get; set; }
        public Event? Event { get; set; }
    }
}