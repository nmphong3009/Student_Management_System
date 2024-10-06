using Dapr.Client;
using Infrastructure.Broker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ITL.Customer.Infrastructure.Broker;

public class BrokerService : IBrokerService
{
    private readonly string BrokerName;
    private readonly ILogger<BrokerService> _logger;
    private readonly IConfiguration _configuration;
    private readonly string GRPC_URI;
    private readonly string HTTP_URI;
    private string enable;
    public BrokerService(ILogger<BrokerService> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
        BrokerName = _configuration.GetSection("Dapr:BrokerName")?.Value;
        GRPC_URI = _configuration.GetSection("Dapr:GRPC_URI")?.Value;
        HTTP_URI = _configuration.GetSection("Dapr:HTTP_URI")?.Value;
        enable = _configuration.GetSection("Dapr:enable")?.Value;
    }
    public async Task<bool> PublishMessage<T>(string topic, T data)
    {
        try
        {
            if (BrokerName == null)
            {
                return false;
            }

            if (enable.Equals("false"))
            {
                return true;
            }
            var daprClient = new DaprClientBuilder()
                .UseHttpEndpoint(HTTP_URI)
                .UseGrpcEndpoint(GRPC_URI)
                .Build();
            var isDaprReady = await daprClient.CheckHealthAsync();
            if (isDaprReady)
            {
                await daprClient.PublishEventAsync<T>(BrokerName, topic, data);
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            _logger.LogError($"Publish {topic} error: ", e);
            return false;
        }
    }
}