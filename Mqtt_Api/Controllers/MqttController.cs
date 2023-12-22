using Microsoft.AspNetCore.Mvc;
using Mqtt_Api.Interface;
using Mqtt_Api.Models;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class MqttController : ControllerBase
{
    private readonly IMqttService _mqttService;

    public MqttController(IMqttService mqttService) => _mqttService = mqttService;

    [HttpGet("status")]
    public IActionResult GetMqttBrokerStatus()
    {
        var isConnected = _mqttService.IsConnected();
        return Ok(new { Status = isConnected ? "Connected" : "Disconnected" });
    }

    [HttpPost("connect")]
    public async Task<IActionResult> ConnectToMqttBroker(
        [FromBody] MqttConnectionRequest request)
    {
        if (string.IsNullOrEmpty(request.BrokerAddress) || request.BrokerPort <= 0)
        {
            return BadRequest(new { Error = "Invalid request parameters" });
        }

        var isConnected = await _mqttService.ConnectAsync(request.BrokerAddress, request.BrokerPort);

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

