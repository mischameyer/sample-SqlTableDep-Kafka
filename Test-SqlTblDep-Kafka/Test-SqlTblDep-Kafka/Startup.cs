using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Test_SqlTblDep_Infrastructure.Data;
using Test_SqlTblDep_Kafka_DataGenerator;

namespace Test_SqlTblDep_Kafka
{
    public class Startup
    {
        IConfigurationRoot Configuration { get; }

        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BigFootDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MSSQL")));

            services.AddLogging();
            services.AddSingleton<IConfigurationRoot>(Configuration);
            services.AddSingleton<IGenerateTestData, GenerateTestData>();
        }
    }
}
