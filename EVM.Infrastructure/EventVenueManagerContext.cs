using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EVM.Infrastructure
{
    public class EventVenueManagerContext(DbContextOptions options) : DbContext(options)
    {
        // DbSets for the entities
        // OnModelCreating method to configure the model
    }
}
