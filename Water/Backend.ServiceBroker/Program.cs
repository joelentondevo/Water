// See https://aka.ms/new-console-template for more information
using Backend.Core.DatabaseObjects.Interfaces;
using Backend.Core.DatabaseObjects;
using Backend.Core.Services;
using Backend.Core.Services.Interfaces;
using Backend.ServiceBroker.ServiceBroker;
using Backend.ServiceBroker.ServiceBroker.Interfaces;
using Microsoft.Extensions.DependencyInjection; 
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Backend.ServiceBroker.TaskExecutors.Interfaces;
using Backend.ServiceBroker.TaskExecutors;
using Backend.ActivityLayer.ActivityHandlers.Interfaces;
using Backend.ActivityLayer.ActitvityHandlers;
using Backend.Core.BusinessObjects;
using Backend.Core.BusinessObjects.Interfaces;
using Backend.ActivityLayer.ActivityHandlers;

var host = Host.CreateDefaultBuilder(args)
.ConfigureServices((context, services) =>
{
    services.AddScoped<IProcesses, Processes>();
    services.AddScoped<ITaskService,  TaskService>();
    services.AddScoped<IDOFactory, DOFactory>();
    services.AddScoped<ILibraryExecutor, LibraryExecutor>();
    services.AddScoped<IBasketExecutor, BasketExecutor>();
    services.AddScoped<ICorrespondenceExecutor, CorrespondenceExecutor>();
    services.AddScoped<ISecurityActivityHandler, SecurityActivityHandler>();
    services.AddScoped<IStoreActivityHandler, StoreActivityHandler>();
    services.AddScoped<ICorrespondenceActivityHandler, CorrespondenceActivityHandler>();
    services.AddScoped<ISecurityBO, SecurityBO>();
    services.AddScoped<IBasketBO, BasketBO>();
    services.AddScoped<IStoreBO, StoreBO>();
    services.AddScoped<ILibraryBO, LibraryBO>();
    services.AddScoped<ICorrespondenceBO, CorrespondenceBO>();
    services.AddScoped<IServicesFactory, ServicesFactory>();
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