using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVM.Domain.Entities
{
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal PricePerUnit { get; set; }
        public ICollection<MaterialOption>? Options { get; set; }
    }
}
