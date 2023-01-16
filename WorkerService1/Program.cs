using WorkerService1;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton<CarDto>();
        services.AddHostedService<Worker>();
        services.AddHostedService<SecondWorker>();
        //services.AddHostedService<FirstBackgroundWorker>();
        //services.AddHostedService<SecondBackgroundWorker>();
    })
    .Build();

await host.RunAsync();
