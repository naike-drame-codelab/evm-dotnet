using EVM.Application.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
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
            catch (StripeException e)
            {
                switch (e.StripeError.Type)
                {
                    case "card_error":
                        return BadRequest(new
                        {
                            Error = "Card Error",
                            Code = e.StripeError.Code,
                            Message = e.StripeError.Message
                        });

                    case "api_connection_error":
                        return StatusCode(StatusCodes.Status503ServiceUnavailable, new
                        {
                            Error = "API Connection Error",
                            Message = "There was a problem connecting to the Stripe API. Please try again later."
                        });

                    case "api_error":
                        return StatusCode(StatusCodes.Status500InternalServerError, new
                        {
                            Error = "API Error",
                            Message = "An error occurred on Stripe's servers. Please try again later."
                        });

                    case "authentication_error":
                        return Unauthorized(new
                        {
                            Error = "Authentication Error",
                            Message = "Authentication with Stripe's API failed. Please check your API keys."
                        });

                    case "invalid_request_error":
                        return BadRequest(new
                        {
                            Error = "Invalid Request Error",
                            Message = "The request to Stripe's API was invalid. Please check the request parameters."
                        });

                    case "rate_limit_error":
                        return StatusCode(StatusCodes.Status429TooManyRequests, new
                        {
                            Error = "Rate Limit Error",
                            Message = "Too many requests were made to the Stripe API in a short period of time. Please try again later."
                        });

                    case "validation_error":
                        return BadRequest(new
                        {
                            Error = "Validation Error",
                            Message = "There was a validation error with the request. Please check the input data."
                        });

                    default:
                        return StatusCode(StatusCodes.Status500InternalServerError, new
                        {
                            Error = "Unknown Error",
                            Message = "An unknown error occurred. Please try again later."
                        });
                }
            }

        }
    }
}
