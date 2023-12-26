namespace MassTransit.Customers.API.Bus
{
    public interface IBusService
    {
        void Publish<T>(T message);
    }
}
