
using EVM.API.Configurations;
using EVM.Application.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;

namespace EVM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly StripeSettings _stripeSettings;

        public CheckoutController(IOptions<StripeSettings> stripeSettings)
        {
            _stripeSettings = stripeSettings.Value; // Fix: Access the Value property of IOptions<T>
        }

        [HttpPost("create-checkout-session")]
        public IActionResult CreateCheckoutSession([FromBody] CheckoutItemDto[] items)
        {
            StripeConfiguration.ApiKey = _stripeSettings.SecretKey; // Use the resolved _stripeSettings

            if (items == null || items.Length == 0)
            {
                return BadRequest("No items provided");
            }

            try
            {
                var lineItems = items.Select(item => new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)(item.Price * 100), // Convert to cents
                        Currency = "eur",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = item.Name
                        }
                    },
                    Quantity = item.Quantity
                }).ToList();

                var options = new SessionCreateOptions
                {
                    PaymentMethodTypes = new List<string> { "card" },
                    LineItems = lineItems,
                    Mode = "payment",
                    SuccessUrl = "http://localhost:4200/success",
                    CancelUrl = "http://localhost:4200/cancel"
                };

                var service = new SessionService();
                Session session = service.Create(options);

                return Ok(new { sessionId = session.Id });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
