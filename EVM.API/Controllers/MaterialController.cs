using EVM.Application.Interfaces.Services;
using EVM.Application.Services;
using EVM.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EVM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController(IMaterialService materialService) : ControllerBase
    {
        [HttpGet] // Handles GET /api/materials
        public async Task<ActionResult<IEnumerable<Material>>> GetMaterials()
        {
            // Replace with your actual data fetching logic
            IEnumerable<Material>? materials = await materialService.GetAllMaterialsAsync();
            return Ok(materials);
        }
    }
}
