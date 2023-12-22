using System;
namespace Mqtt_Api.Models
{
    public class MqttConnectionRequest
    {
        public required string BrokerAddress { get; set; }
        public int BrokerPort { get; set; }
    }
}