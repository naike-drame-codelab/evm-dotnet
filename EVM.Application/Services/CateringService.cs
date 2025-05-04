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
    public class CateringService(ICateringRepository cateringRepository) : ICateringService
    {
        public async Task<IEnumerable<Catering>> GetAllCateringsAsync()
        {
            return await cateringRepository.FindAsync();
        }

        public Task<Catering> GetCateringByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
