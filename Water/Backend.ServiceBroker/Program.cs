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
    services.AddHostedService<HeartBeat>();
})
.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
})
.Build();

CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

await host.RunAsync(cancellationTokenSource.Token);
