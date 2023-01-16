using WorkerService1;

public class SecondBackgroundWorker : IHostedService, IDisposable
{
    private Timer? _timer = null;
    private CarDto _car;

    public SecondBackgroundWorker(CarDto carDto)
    {
        _car = carDto;
    }
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(async o => await DoWork(o), null, TimeSpan.Zero, TimeSpan.FromSeconds(1));

        return Task.CompletedTask;
    }

    private async Task DoWork(object? state)
    {
        Console.WriteLine(nameof(SecondBackgroundWorker));
        Console.WriteLine($"Name: {_car?.Name}\nDescription: {_car.Description}\nWeight: {_car.Weight}");
        Console.WriteLine();

        await Task.Delay(1000);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}
