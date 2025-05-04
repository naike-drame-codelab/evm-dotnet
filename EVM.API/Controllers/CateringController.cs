using EVM.Application.Interfaces.Services;
using EVM.Application.Services;
using EVM.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EVM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CateringController(ICateringService cateringService) : ControllerBase
    {
        [HttpGet] // Handles GET /api/caterings
        public async Task<ActionResult<IEnumerable<Catering>>> GetCaterings()
        {
            // Replace with your actual data fetching logic
            IEnumerable<Catering>? caterings = await cateringService.GetAllCateringsAsync();
            return Ok(caterings);
        }
    }
}
