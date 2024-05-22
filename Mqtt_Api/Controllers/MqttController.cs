using Microsoft.AspNetCore.Mvc;
using Mqtt_Api.Interface;
using Mqtt_Api.Models;

namespace Mqtt_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MqttController (IMqttService mqttService): ControllerBase
{
    
    [HttpGet("status")]
    public async Task<IActionResult> GetMqttBrokerStatus(
        [FromQuery] string brokerAddress,
        [FromQuery] int brokerPort)
    {
       
        var isBrokerConnected = await mqttService.CheckBrokerStatus(brokerAddress, brokerPort);

        return Ok(new
        {
            BrokerStatus = isBrokerConnected ? "Broker Connected" : "Broker Disconnected"
        });
    }


    [HttpPost("connect")]
    public async Task<IActionResult> ConnectToMqttBroker(
        [FromBody] MqttConnectionRequest request)
    {
        if (string.IsNullOrEmpty(request.BrokerAddress) || request.BrokerPort <= 0)
        {
            return BadRequest(new { Error = "Invalid request parameters" });
        }

        var isConnected = await mqttService.ConnectAsync(request.BrokerAddress, request.BrokerPort);

        if (isConnected)
        {
            return Ok(new { Status = "Connected" });
        }
        else
        {
            return BadRequest(new { Error = "Failed to connect to the MQTT broker" });
        }
    }
}