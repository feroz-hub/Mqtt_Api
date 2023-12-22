using Mqtt_Api.Interface;
using Mqtt_Api.Service;
using MQTTnet;
using MQTTnet.Client;

public class MqttService : IMqttService
{
    private readonly IMqttClient _mqttClient;

    public MqttService()
    {
        _mqttClient = new MqttFactory().CreateMqttClient();
    }

    public async Task<bool> CheckBrokerStatus(string brokerAddress, int brokerPort)
    {
       return await MqttBrokerStatusChecker.IsBrokerConnected(brokerAddress, brokerPort);
    }

    public async Task<bool> ConnectAsync(string brokerAddress, int brokerPort)
    {
        try
        {
            var options = new MqttClientOptionsBuilder()
                .WithTcpServer(brokerAddress, brokerPort)
                .Build();

            await _mqttClient.ConnectAsync(options);
            return _mqttClient.IsConnected;
        }
        catch (Exception)
        {
            return false;
        }
    }

   
}
