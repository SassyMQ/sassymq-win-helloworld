using SassyMQ.DEMO.Lib.RMQActors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var world = new SMQWorld();


            world.ProgrammerHelloReceived += World_ProgrammerHelloReceived;
        }

        private static void World_ProgrammerHelloReceived(object sender, SassyMQ.Lib.RabbitMQ.PayloadEventArgs<DEMOPayload> e)
        {
            Console.WriteLine("RECEIVED Message From Programmer: {0}", e.Payload.Content);
            e.Payload.Content = "REPLY";
        }
    }
}
