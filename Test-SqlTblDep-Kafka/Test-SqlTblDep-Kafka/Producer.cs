using Confluent.Kafka;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Test_SqlTblDep_Infrastructure.Entities;

namespace Test_SqlTblDep_Kafka
{
    public class Producer: IProducer
    {
        private IProducer<string, string> producer = null;
        private ProducerConfig producerConfig = null;
        public Producer()
        {

            AutoResetEvent _closing = new AutoResetEvent(false);
                       
            CreateConfig();
            CreateProducer();
           
        }
        void CreateConfig()
        {
            producerConfig = new ProducerConfig
            {
                BootstrapServers = "localhost:9092",
            };
        }

        void CreateProducer()
        {
            var pb = new ProducerBuilder<string, string>(producerConfig);
            producer = pb.Build();
        }

        public async void SendMessage(string topic, BigFoot bigfoot, bool display, int key)
        {                 

            var value = JsonConvert.SerializeObject(bigfoot);

            var msg = new Message<string, string>
            {
                Key = bigfoot.Id.ToString(),
                Value = value
            };

            DeliveryResult<string, string> delRep;

            if (key > 1)
            {
                var p = new Partition(key);
                var tp = new TopicPartition(topic, p);
                delRep = await producer.ProduceAsync(tp, msg);
            }
            else
            {
                delRep = await producer.ProduceAsync(topic, msg);
            }

            var topicOffset = delRep.TopicPartitionOffset;

            if (display) { Console.WriteLine($"Delivered '{delRep.Value}' to: {topicOffset}"); }
        }

    }
}
