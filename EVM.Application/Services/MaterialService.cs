using EVM.Application.Interfaces.Services;
using EVM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVM.Application.Services
{
    public class MaterialService : IMaterialService
    {
        public Task<IEnumerable<Material>> GetAllMaterialsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Material> GetMaterialByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
