using System;
using System.Collections.Generic;
using System.Text;
using Test_SqlTblDep_Infrastructure.Entities;

namespace Test_SqlTblDep_Kafka
{
    public interface IProducer
    {
        void SendMessage(string topic, BigFoot bigfoot, bool display, int key);
    }
}
