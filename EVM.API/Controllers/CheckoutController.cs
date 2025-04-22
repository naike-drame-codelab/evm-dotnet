using EVM.Application.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;

namespace EVM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        [HttpPost("Checkout")]
        public ActionResult Checkout([FromBody] List<CheckoutItemDto> items)
        {
            if (items == null || !items.Any())
            {
                return BadRequest("No items provided");
            }

            try
            {
                var options = new SessionCreateOptions
                {
                    PaymentMethodTypes = new List<string> { "card" },
                    LineItems = items.Select(item => new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency = "usd",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = item.Name
                            },
                            UnitAmount = (long)(item.Price * 100) // Convert to cents
                        },
                        Quantity = item.Quantity
                    }).ToList(),
                    Mode = "payment",
                    SuccessUrl = "http://{{ Your-domain }}/dashboard",
                    CancelUrl = "http://{{ Your-domain }}/dashboard"
                };

                SessionService? service = new SessionService();
                Session? session = service.Create(options);

                return Ok(new { sessionId = session.Id });
            }
            catch (Exception ex)
            {
                // Log the error
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
