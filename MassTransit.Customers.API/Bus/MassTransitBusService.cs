using MassTransit;

namespace MassTransit.Customers.API.Bus
{
    public class MassTransitBusService : IBusService
    {
        private readonly IBus _bus;

        public MassTransitBusService(IBus bus)
        {
            _bus = bus;
        }

        public void Publish<T>(T message)
        {
            _bus.Publish(message);
        }
    }
}
