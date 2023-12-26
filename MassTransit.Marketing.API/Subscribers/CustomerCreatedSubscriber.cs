using System.Text.Json;
using System.Text;
using System;
using MessagingEvents.Shared;
using MassTransit;
using MessagingEvents.Shared.Services;

namespace MassTransit.Marketing.API.Subscribers
{
    public class CustomerCreatedSubscriber : IConsumer<CustomerCreated>
    {
        private readonly IServiceProvider _serviceProvider;

        public CustomerCreatedSubscriber(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Consume(ConsumeContext<CustomerCreated> context)
        {
            var @event = context.Message;

            using (var scope = _serviceProvider.CreateScope())
            {
                var service = scope.ServiceProvider.GetRequiredService<INotificationService>();

                service.SendEmail(@event.Email, "Boas vindas", new Dictionary<string, string> { { "name", @event.FullName } });
            }
        }
    }
}
