using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WorkerService_DI
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly AppDbContext _ctx;

        public Worker(ILogger<Worker> logger, AppDbContext ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                _logger.LogWarning($"O valor é: {_ctx.MinhaPropriedade}");
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
