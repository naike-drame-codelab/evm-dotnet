using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;
using Stripe.Events;
using System.Text.Json;
using EVM.Application.Interfaces.Repositories;
using EVM.Domain.Entities;
using EVM.Domain.Enums;
using EVM.Application.Interfaces.Services;

namespace EVM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripeWebhookController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IEventRepository _eventRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ITicketService ticketService;

        public StripeWebhookController(
            ITicketRepository ticketRepository,
            IEventRepository eventRepository,
            ICustomerRepository customerRepository)
        {
            _ticketRepository = ticketRepository;
            _eventRepository = eventRepository;
            _customerRepository = customerRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Handle()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            try
            {
                var stripeEvent = EventUtility.ConstructEvent(
                    json,
                    Request.Headers["Stripe-Signature"],
                    "your-stripe-webhook-secret" // Replace with your Stripe webhook secret
                );

                if (stripeEvent.Type == Stripe.Events.CheckoutSessionCompleted)
                     // Add this namespace to resolve 'Events'
                {
                    var session = stripeEvent.Data.Object as Session;

                    if (session != null)
                    {
                        // Retrieve customer email and metadata
                        var customerEmail = session.CustomerDetails.Email;
                        var eventId = session.Metadata["eventId"]; // Assuming you pass eventId in metadata
                        var ticketType = Enum.Parse<TicketType>(session.Metadata["ticketType"]); // Assuming you pass ticketType in metadata
                        var ticketPrice = decimal.Parse(session.Metadata["ticketPrice"]); // Assuming you pass ticketPrice in metadata
                        var quantity = int.Parse(session.Metadata["quantity"]);

                        // Check if the event exists
                        var eventEntity = await _eventRepository.FindOneAsync(Guid.Parse(eventId));
                        if (eventEntity == null)
                        {
                            return NotFound(new { Message = "Event not found." });
                        }

                        // Check if the ticket is available
                        var isTicketAvailable = await ticketService.IsTicketAvailable(Guid.Parse(eventId), ticketType, quantity);

                        // Check if the customer exists, or create a new one
                        var customer = await _customerRepository.FindOneWhereAsync(c => c.Email == customerEmail);
                        if (customer == null)
                        {
                            customer = new Domain.Entities.Customer
                            {
                                Email = customerEmail
                            };
                            await _customerRepository.AddAsync(customer);
                        }

                        // Create a new ticket
                        var ticket = new Ticket
                        {
                            Id = Guid.NewGuid(),
                            EventId = Guid.Parse(eventId),
                            CustomerId = customer.Id,
                            Type = TicketType.Value, //check how to get value of ticketType
                            Price = ticketPrice,
                            PurchaseDate = DateTime.UtcNow,
                            QuantityAvailable = 1,
                            QuantitySold = 1,
                            IsUsed = false
                        };

                        await _ticketRepository.AddAsync(ticket);

                        return Ok(new { Message = "Ticket created successfully." });
                    }
                }

                return Ok();
            }
            catch (StripeException e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }
    }
}
