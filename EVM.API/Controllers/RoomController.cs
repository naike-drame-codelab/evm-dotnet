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
                // Simulate fetching room details
                var roomDetails = new { RoomId = roomId, RoomName = "Conference Room A" };
                return Ok(roomDetails);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        // get rooms list
        [HttpGet("list")]
        public async Task<IActionResult> GetRoomList()
        {
            try
            {
                // Simulate fetching room list
                var roomList = new List<object>
                {
                    new { RoomId = Guid.NewGuid(), RoomName = "Conference Room A" },
                    new { RoomId = Guid.NewGuid(), RoomName = "Meeting Room B" }
                };
                return Ok(roomList);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }
        }
}
