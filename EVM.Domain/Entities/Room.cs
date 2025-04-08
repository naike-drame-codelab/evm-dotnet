using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVM.Domain.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Capacity { get; set; }
        public bool IsAvailable { get; set; } = true;
        public ICollection<RoomReservation> Reservations { get; set; } = new List<RoomReservation>();
    }
}
