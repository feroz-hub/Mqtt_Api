using Mqtt_Api.Interface;
using MQTTnet;
using MQTTnet.Client;

public class MqttService:IMqttService
{
    private readonly IMqttClient _mqttClient;

    public MqttService()
    {
        _mqttClient = new MqttFactory().CreateMqttClient();
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

    public bool IsConnected()
    {
        return _mqttClient.IsConnected;
    }
}
