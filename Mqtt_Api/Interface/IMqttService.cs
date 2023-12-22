using System;
namespace Mqtt_Api.Interface
{
	public interface IMqttService
	{
        public Task<bool> ConnectAsync(string brokerAddress, int brokerPort);
    }
}

