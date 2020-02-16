using System;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.Enums;
using TableDependency.SqlClient.Base.EventArgs;
using Test_SqlTblDep_Infrastructure.Entities;

namespace Test_SqlTblDep_Kafka
{
    public class Listener : IListener
    {

        private readonly IProducer _producer;
        public Listener(IProducer producer)
        {
            _producer = producer;
        }

        public void StartListener()
        {
            var originalForegroundColor = Console.ForegroundColor;

            Console.ResetColor();

            using (var dep = new SqlTableDependency<BigFoot>("Server=localhost;Database=bigfoot;Integrated Security=True;", null, null, null, null, null, DmlTriggerType.All, false, false))
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

        private void OnError(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs e)
        {
            Console.WriteLine(Environment.NewLine);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.Message);
            Console.WriteLine(e.Error?.Message);
            Console.ResetColor();
        }

        private void OnStatusChanged(object sender, StatusChangedEventArgs e)
        {
            Console.WriteLine(Environment.NewLine);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"SqlTableDependency Status = {e.Status.ToString()}");
            Console.ResetColor();
        }

        private void Changed(object sender, RecordChangedEventArgs<BigFoot> e)
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

                _producer.SendMessage("BigFoot", changedEntity, false, 1);

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

                _producer.SendMessage("BigFoot", changedEntity, false, 1);
            }
            
        }
    }
}
