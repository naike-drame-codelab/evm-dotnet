using EVM.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EVM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController(IRoomService roomService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetRoomDetails(Guid roomId)
        {
            try
            {
                var roomDetails = await roomService.GetRoomByIdAsync(roomId);
                return Ok(roomDetails);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetRoomList()
        {
            try
            {
                var roomList = await roomService.GetAllRoomsAsync();
                return Ok(roomList);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }

        // New endpoint to check room availability
        [HttpGet("{roomId}/availability")]
        public async Task<IActionResult> CheckRoomAvailability(int roomId, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                bool isAvailable = await roomService.IsRoomAvailableAsync(roomId, startDate, endDate);
                return Ok(new { RoomId = roomId, IsAvailable = isAvailable });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
