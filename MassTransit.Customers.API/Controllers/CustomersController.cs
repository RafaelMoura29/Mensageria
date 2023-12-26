using MassTransit.Customers.API.Bus;
using MessagingEvents.Shared;
using MessagingEvents.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace MassTransit.Customers.API.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly IBusService _busService;

        public CustomersController(IBusService busService)
        {
            _busService = busService;
        }

        [HttpPost]
        public IActionResult Post(CustomerInputModel model)
        {
            var @event = new CustomerCreated(model.Id, model.FullName, model.Email, model.PhoneNumber, model.BirthDate);

            _busService.Publish(@event);

            return NoContent();
        }
    }
}
