using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVM.Application.Interfaces.Repositories;
using EVM.Domain.Entities;

namespace EVM.Infrastructure.Repositories
{
    public class AdminRepository(EventVenueManagerContext ctx) : RepositoryBase<Admin>(ctx), IAdminRepository
    {
    }
}
