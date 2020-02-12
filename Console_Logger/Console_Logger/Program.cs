//using Serilog;
using System;
//using SimpleInjector;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace Console_Logger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var collection = new ServiceCollection();

            collection.AddScoped<IDemoService, DemoService>();

            // ...

            // Add other services

            // ...

            var serviceProvider = collection.BuildServiceProvider();



            var service = serviceProvider.GetService<IDemoService>();

            service.DoSomething();



            serviceProvider.Dispose();


            //setup our DI
            var collection = new ServiceCollection()
                .AddLogging()
                //            .AddSingleton<IFooService, FooService>()
                //            .AddSingleton<IBarService, BarService>()
                .BuildServiceProvider();

            var serviceProvider = collection.

            //configure console logging
            serviceProvider.buid
                .GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Debug);

            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();
            logger.LogDebug("Starting application");

            //do the actual work here
            var bar = serviceProvider.GetService<IBarService>();
            bar.DoSomeRealWork();

            logger.LogDebug("All done!");
        }

    }
}

