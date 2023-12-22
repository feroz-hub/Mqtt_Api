using System;
namespace Mqtt_Api.Models
{
    public class MqttConnectionRequest
    {
        public string BrokerAddress { get; set; }
        public int BrokerPort { get; set; }
    }
}

