using EVM.Application.Interfaces.Services;
using EVM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVM.Application.Services
{
    public class CateringService : ICateringService
    {
        public Task<IEnumerable<Catering>> GetAllCateringsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Catering> GetCateringByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
