using System;
namespace Mqtt_Api.Interface
{
	public interface IMqttService
	{
        public Task<bool> ConnectAsync(string brokerAddress, int brokerPort);
        public Task<bool> CheckBrokerStatus(string brokerAddress, int brokerPort);
        
    }
}

