using System;

namespace Test_SqlTblDep_Kafka.SqlListener
{
    public class SqlListener
    {

        public void Listener()
        {

            using (var dep = new SqlTableDependency<Product>(connectionString, "Products", mapper: mapper, includeOldValues: true, filter: whereCondition))
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
    }
}
