using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WorkerService1
{
    public class Worker2 : BackgroundService
    {

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Funcoes.AppendToFile(@"d:\worker2.txt", "2 " + DateTimeOffset.Now.ToString());
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
