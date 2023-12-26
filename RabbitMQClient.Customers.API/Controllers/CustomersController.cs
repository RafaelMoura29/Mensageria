using MessagingEvents.Shared;
using MessagingEvents.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using RabbitMQClient.Customers.API.Bus;

namespace RabbitMQClient.Customers.API.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        const string ROUTING_KEY = "customer-created";
        private readonly IBusService _busService;

        public CustomersController(IBusService busService)
        {
            _busService = busService;
        }

        [HttpPost]
        public IActionResult Post(CustomerInputModel model)
        {
            var @event = new CustomerCreated(model.Id, model.FullName, model.Email, model.PhoneNumber, model.BirthDate);

            _busService.Publish(ROUTING_KEY, @event);

            return NoContent();
        }
    }
}
