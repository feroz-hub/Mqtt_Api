using Mqtt_Api.Interface;

namespace Mqtt_Api.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static void AddMqttService(this IServiceCollection services)
        {
            services.AddScoped<IMqttService, MqttService>();
           
        }
    }

}