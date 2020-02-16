using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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

            var switchMappings = new Dictionary<string, string>()
             {
                 { "-action", "key1" },
                { "-param", "key2" }
             };
            var builder = new ConfigurationBuilder();
            builder.AddCommandLine(args, switchMappings);

            var config = builder.Build();

            if (args.Length == 0)
            {
                Console.WriteLine("Invalid argument!");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                try
                {
                    var param1 = config["Key1"];
                    var param2 = config["Key2"];

                    switch (param1)
                    {
                        case "generate":
                            var datagenerator = serviceProvider.GetService<IGenerateTestData>();
                            datagenerator.GenerateRandomTestData(Convert.ToInt32(config["Key2"]));
                            break;
                        case "listen":
                            var listener = serviceProvider.GetService<IListener>();
                            listener.StartListener();
                            break;                        
                        default:
                            Console.WriteLine("Invalid argument!");
                            Console.ReadKey();
                            Environment.Exit(0);
                            break;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
        }

       

    }
}
