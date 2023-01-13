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

        public SecondWorker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                _logger.LogWarning("My name is {name}", this.GetType().Name);

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
