using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerService1
{
    public class SecondWorker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private CarDto _car;

        public SecondWorker(ILogger<Worker> logger, CarDto car)
        {
            _logger = logger;
            _car = car;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                Console.WriteLine($"Name: {_car?.Name}\nDescription: {_car.Description}\nWeight: {_car.Weight}");

                _logger.LogWarning("My name is {name}", this.GetType().Name);

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
