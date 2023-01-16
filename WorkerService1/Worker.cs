namespace WorkerService1
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private CarDto _car;

        public Worker(ILogger<Worker> logger, CarDto car)
        {
            _logger = logger;
            _car = car;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                _logger.LogWarning("My name is {name}", this.GetType().Name);

                if (_car.Name == null)
                {
                    _car.Name = "Ford";
                    _car.Weight = 10000;
                    _car.Description = $"{this.GetType().Name}";
                }
                else
                {
                    _car.Weight += 1;
                }

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}