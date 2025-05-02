using EVM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVM.Application.Interfaces.Services
{
    public interface ICateringService
    {
        // Define methods related to catering management here
        Task<IEnumerable<Catering>> GetAllCateringsAsync();
        Task<Catering> GetCateringByIdAsync(int id);
   
    }
}
