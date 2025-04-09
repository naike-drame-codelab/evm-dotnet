using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVM.Domain.Entities
{
    public class Catering
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal PricePerPerson { get; set; }
        
        public ICollection<CateringOption>? Options { get; set; }
    }
}
