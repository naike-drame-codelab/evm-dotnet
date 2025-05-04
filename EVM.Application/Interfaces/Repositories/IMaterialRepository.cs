using EVM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVM.Application.Interfaces.Repositories
{
    // Removed duplicate definition of IMaterialRepository to resolve CS0101 error.  
    public interface IMaterialRepository : IRepositoryBase<Material>
    {
        // Add any additional methods specific to Material repository here if needed.  
    }
}
