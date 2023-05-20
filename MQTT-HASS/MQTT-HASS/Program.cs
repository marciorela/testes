// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using MQTTnet.Server;

Console.WriteLine("Hello, World!");

ConfigureServices();

public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();

    var optionsBuilder = new MqttServerOptionsBuilder();
}