using System;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;

namespace Mqtt_Api.Service
{
    public static class MqttBrokerStatusChecker
    {
        public static async Task<bool> IsBrokerConnected(string brokerAddress, int brokerPort)
        {
            var factory = new MqttFactory();
            var mqttClient = factory.CreateMqttClient();

            var options = new MqttClientOptionsBuilder()
                .WithTcpServer(brokerAddress, brokerPort)
                .Build();

            try
            {
                await mqttClient.ConnectAsync(options);

                // Send a ping to check if the broker is responsive
                await mqttClient.PingAsync();

                // If no exception is thrown during ping, consider the broker as responsive
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (mqttClient.IsConnected)
                {
                    await mqttClient.DisconnectAsync();
                }
            }
        }
    }
}
