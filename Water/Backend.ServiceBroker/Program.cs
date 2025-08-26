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

var heartBeat = host.RunAsync(cancellationTokenSource.Token);

    Console.WriteLine("Press any key to shut down...");
    Console.ReadKey(true);
    cancellationTokenSource.Cancel();
    cancellationTokenSource.Dispose();

await heartBeat;