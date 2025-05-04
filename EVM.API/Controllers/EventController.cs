using Elfie.Serialization;
using EVM.Application.DTO;
using EVM.Application.Interfaces.Services;
using EVM.Application.Services;
using EVM.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EVM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController(IEventService eventService) : ControllerBase
    {
        [HttpGet] // Handles GET requests to /api/event
        public async Task<IActionResult> GetEvents()
        {
            try { 

            List<Event>? events = (List<Event>?)await eventService.GetEvents(); // Ensure the method returns a value, not void
            return Ok(events);
        }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpGet("{eventId}")]
        public async Task<IActionResult> GetEventDetails(Guid eventId)
        {
            try
            {
                EventDetailsDTO? eventDetails = await eventService.GetEventDetailsAsync(eventId);
                return Ok(eventDetails);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpGet("{eventId}/estimated-cost")]
        public async Task<IActionResult> GetEstimatedCost(Guid eventId)
        {
            try
            {
                decimal estimatedCost = await eventService.CalculateEstimatedCostAsync(eventId);
                return Ok(new { EstimatedCost = estimatedCost });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] EventCreateDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (dto.ClientId <= 0)
                {
                    return BadRequest(new { Message = "A valid ClientId is required." });
                }

                if (dto.RoomReservations == null || dto.RoomReservations.Count == 0)
                {
                    return BadRequest(new { Message = "At least one room reservation is required." });
                }

                Event e = await eventService.CreateEvent(dto);
                return Created("event/" + e.Id, new EventCreateDTOResult(e));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPut("{eventId}")]
        public async Task<IActionResult> UpdateEvent(Guid eventId, [FromBody] Event updatedEvent)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                Event e = await eventService.UpdateEvent(eventId, updatedEvent);
                return Ok(e);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpDelete("{eventId}")]
        public async Task<IActionResult> DeleteEvent(Guid eventId)
        {
            try
            {
                Event e = await eventService.DeleteEvent(eventId);
                return Ok(e);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        // TODO: Implement GET /api/rooms : Retourne la liste des rooms.

	    // TODO: GET /api/materials : Retourne la liste des matériels.

	    // TODO: GET /api/caterings : Retourne la liste des options de catering.


    }
}
