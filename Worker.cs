using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace TimeStampMaker.WorkerServiceExample
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        // Executes the worker service logic
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Service TimeStamp started at {time}", DateTime.Now);

            // Continuously runs until cancellation is requested
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at {time}", DateTimeOffset.Now);
                await Task.Delay(5000, stoppingToken);
            }

            _logger.LogInformation("Service stopped at {time}", DateTime.Now);
        }

        // Called when the worker service is starting
        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Worker service starting");
            await base.StartAsync(cancellationToken);
        }

        // Called when the worker service is stopping
        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Worker service stopping at {time}", DateTime.Now);
            await base.StopAsync(cancellationToken);
        }
    }
}
