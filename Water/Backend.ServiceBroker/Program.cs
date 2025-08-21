// See https://aka.ms/new-console-template for more information
using Backend.Core.Services;
using Backend.ServiceBroker.ServiceBroker;
using Backend.ServiceBroker.ServiceBroker.Interfaces;
using Microsoft.Extensions.DependencyInjection; 
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var host = Host.CreateDefaultBuilder(args)
.ConfigureServices((context, services) =>
{
    services.AddScoped<IProcesses, Processes>();
})
.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
})
.Build();

Processes processes = new Processes();
HeartBeat heartBeat = new HeartBeat(processes);
CancellationToken cancellationToken = new CancellationToken();

await heartBeat.RunAsync(cancellationToken);
