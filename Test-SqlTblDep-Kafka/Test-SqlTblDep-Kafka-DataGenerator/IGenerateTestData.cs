using System;
using System.Collections.Generic;
using System.Text;

namespace Test_SqlTblDep_Kafka_DataGenerator
{
    public interface IGenerateTestData
    {
        public void GenerateRandomTestData(int? count);
    }
}
