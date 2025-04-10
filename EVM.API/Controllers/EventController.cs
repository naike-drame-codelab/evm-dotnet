using EVM.Application.DTO;
using EVM.Application.Interfaces.Services;
using EVM.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EVM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController(IEventService eventService) : ControllerBase
    {
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

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] EventCreateDTO dto)
        {
            try
            {
                Event e = await eventService.CreateEvent(dto);
                return Created("event/" + e.Id, e);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }




        //private readonly EventVenueManagerContext _context;

        //public EventController(EventVenueManagerContext context)
        //{
        //    _context = context;
        //}

        //// GET: api/Event
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        //{
        //    return await _context.Events.ToListAsync();
        //}

        //// GET: api/Event/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Event>> GetEvent(Guid id)
        //{
        //    var @event = await _context.Events.FindAsync(id);

        //    if (@event == null)
        //    {
        //        return NotFound();
        //    }

        //    return @event;
        //}

        //// PUT: api/Event/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutEvent(Guid id, Event @event)
        //{
        //    if (id != @event.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(@event).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EventExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Event
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Event>> PostEvent(Event @event)
        //{
        //    _context.Events.Add(@event);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetEvent", new { id = @event.Id }, @event);
        //}

        //// DELETE: api/Event/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteEvent(Guid id)
        //{
        //    var @event = await _context.Events.FindAsync(id);
        //    if (@event == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Events.Remove(@event);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool EventExists(Guid id)
        //{
        //    return _context.Events.Any(e => e.Id == id);
        //}
    }
}
