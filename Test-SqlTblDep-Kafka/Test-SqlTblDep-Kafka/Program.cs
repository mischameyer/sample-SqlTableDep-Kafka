using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base;
using TableDependency.SqlClient.Base.Abstracts;
using TableDependency.SqlClient.Base.Enums;
using TableDependency.SqlClient.Base.EventArgs;
using TableDependency.SqlClient.Where;
using Test_SqlTblDep_Infrastructure.Entities;
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
                            Listener();
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

        public static void Listener()
        {                        
            var originalForegroundColor = Console.ForegroundColor;

            Console.ResetColor();
            
            using (var dep = new SqlTableDependency<BigFoot>("Server=localhost;Database=bigfoot;Integrated Security=True;",null, null, null, null, null, DmlTriggerType.All,false, false))
            {
                dep.OnChanged += Changed;
                dep.OnError += OnError;
                dep.OnStatusChanged += OnStatusChanged;

                dep.Start();

                Console.WriteLine();
                Console.WriteLine("Waiting for receiving notifications (db objects naming: " + dep.DataBaseObjectsNamingConvention + ")...");
                Console.WriteLine("Press a key to stop.");
                Console.ReadKey();
            }

        }

        private static void OnError(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs e)
        {
            Console.WriteLine(Environment.NewLine);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.Message);
            Console.WriteLine(e.Error?.Message);
            Console.ResetColor();
        }

        private static void OnStatusChanged(object sender, StatusChangedEventArgs e)
        {
            Console.WriteLine(Environment.NewLine);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"SqlTableDependency Status = {e.Status.ToString()}");
            Console.ResetColor();
        }

        private static void Changed(object sender, RecordChangedEventArgs<BigFoot> e)
        {
            Console.WriteLine(Environment.NewLine);

            if (e.ChangeType != ChangeType.None)
            {
                var changedEntity = e.Entity;
                Console.WriteLine("Id: " + changedEntity.Id);
                Console.WriteLine("Name: " + changedEntity.Name);
                Console.WriteLine("isParent: " + changedEntity.isParent);
                Console.WriteLine("Height: " + changedEntity.Height);
                Console.WriteLine("Weight: " + changedEntity.Weight);
                Console.WriteLine("Mom: " + changedEntity.Mom);
                Console.WriteLine("Daddy: " + changedEntity.Daddy);
                Console.WriteLine("Birthdate: " + changedEntity.Birthdate);
                Console.WriteLine("EyeColor: " + changedEntity.EyeColor);
                Console.WriteLine("FootSize: " + changedEntity.FootSize);
            }

            if (e.ChangeType == ChangeType.Update && e.EntityOldValues != null)
            {
                Console.WriteLine(Environment.NewLine);

                var changedEntity = e.EntityOldValues;
                Console.WriteLine("Id (OLD): " + changedEntity.Id);
                Console.WriteLine("Name (OLD): " + changedEntity.Name);
                Console.WriteLine("isParent (OLD): " + changedEntity.isParent);
                Console.WriteLine("Height (OLD): " + changedEntity.Height);
                Console.WriteLine("Weight (OLD): " + changedEntity.Weight);
                Console.WriteLine("Mom (OLD): " + changedEntity.Mom);
                Console.WriteLine("Daddy (OLD): " + changedEntity.Daddy);
                Console.WriteLine("Birthdate (OLD): " + changedEntity.Birthdate);
                Console.WriteLine("EyeColor (OLD): " + changedEntity.EyeColor);
                Console.WriteLine("FootSize (OLD): " + changedEntity.FootSize);
            }
        }

    }
}
