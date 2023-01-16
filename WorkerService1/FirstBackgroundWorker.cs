using WorkerService1;

public class FirstBackgroundWorker : IHostedService, IDisposable
{
    private Timer? _timer = null;
    private CarDto _car;

    public FirstBackgroundWorker(CarDto carDto)
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
        Console.WriteLine(nameof(FirstBackgroundWorker));
        Console.WriteLine();

        if (_car.Name == null)
        {
            _car.Description = $"{nameof(FirstBackgroundWorker)}";
            _car.Name = "Ferrari";
            _car.Weight = 1;
        }
        else
        {
            _car.Weight += 1;
        }

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
