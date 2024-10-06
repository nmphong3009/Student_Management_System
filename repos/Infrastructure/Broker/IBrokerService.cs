namespace Infrastructure.Broker;

public interface IBrokerService
{
    public Task<bool> PublishMessage<T>(string topic, T data);
}