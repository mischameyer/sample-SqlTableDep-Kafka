using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Test_SqlTblDep_Infrastructure.Data;
using Test_SqlTblDep_Infrastructure.Entities;

namespace Test_SqlTblDep_Kafka_DataGenerator
{
    public class GenerateTestData : IGenerateTestData
    {
        private readonly BigFootDbContext _dbContext;
        private readonly ILogger<GenerateTestData> _logger;


        public GenerateTestData(ILoggerFactory loggerFactory, IConfigurationRoot config, BigFootDbContext dbContext)
        {
            _logger = loggerFactory.CreateLogger<GenerateTestData>();
            _dbContext = dbContext;
        }

        public void GenerateRandomTestData(int? count)
        {
            _logger.LogInformation(string.Format("Generate {0} new items!", count));

            var _eyeColors = _dbContext.EyeColor.ToList();

            //Generate parents
            for(int i = 0; i < 50; i++)
            {

                var parent = Parent(_eyeColors);

                _dbContext.BigFoot.Add(parent);
            }

            _dbContext.SaveChanges();

            //Generate children
            var _parents = _dbContext.BigFoot.Where(p => p.isParent).ToList();

            for (int i = 0; i < count; i++)
            {

                var child = Child(_eyeColors, _parents);

                _dbContext.BigFoot.Add(child);

            }

            _dbContext.SaveChanges();

        }


        public BigFoot Parent(List<EyeColor> eyeColors)
        {
            var random = new Random();
            var index = random.Next(eyeColors.Count);

            var obj = new BigFoot
            {
                Id = Guid.NewGuid(),
                Name = GenerateName(10),
                Birthdate = RandomDayFunc(),
                Daddy = Guid.NewGuid(),
                Mom = Guid.NewGuid(),
                EyeColor = eyeColors[index].Id,
                FootSize = random.Next(30, 50),
                Height = random.Next(100, 400),
                Weight = random.Next(200, 500),
                isParent = true
            };

            return obj;
        }

        public BigFoot Child(List<EyeColor> eyeColors, List<BigFoot> parents)
        {
            var random = new Random();
            var index = random.Next(eyeColors.Count);

            var index2 = random.Next(parents.Count);
            var index3 = random.Next(parents.Count);

            var obj = new BigFoot
            {
                Id = Guid.NewGuid(),
                Name = GenerateName(10),
                Birthdate = RandomDayFunc(),
                Daddy = parents[index2].Id,
                Mom = parents[index3].Id,
                EyeColor = eyeColors[index].Id,
                FootSize = random.Next(10, 40),
                Height = random.Next(50, 200),
                Weight = random.Next(100, 200),
                isParent = false
            };

            return obj;

        }
       

        public static string GenerateName(int len)
        {
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2; 
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return Name;
        }

        public DateTime RandomDayFunc()
        {
            DateTime start = new DateTime(1995, 1, 1);
            Random gen = new Random();
            int range = ((TimeSpan)(DateTime.Today - start)).Days;

            return start.AddDays(gen.Next(range));            
        }
    }
}
