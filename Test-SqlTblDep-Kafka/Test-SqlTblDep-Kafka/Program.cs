using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Test_SqlTblDep_Kafka_DataGenerator;

namespace Test_SqlTblDep_Kafka
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();

            Startup startup = new Startup();
            startup.ConfigureServices(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            serviceProvider
                .GetService<ILoggerFactory>();

            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();

            logger.LogDebug("Logger is working!");

            var datagenerator = serviceProvider.GetService<IGenerateTestData>();
            datagenerator.GenerateRandomTestData(100);
            
        }
    }
}
