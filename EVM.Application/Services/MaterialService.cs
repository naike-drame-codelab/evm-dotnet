using EVM.Application.Interfaces.Repositories;
using EVM.Application.Interfaces.Services;
using EVM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVM.Application.Services
{
    public class MaterialService(IMaterialRepository materialRepository) : IMaterialService
    {
        public async Task<IEnumerable<Material>> GetAllMaterialsAsync()
        {
            return await materialRepository.FindAsync();
        }

        public Task<Material> GetMaterialByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
