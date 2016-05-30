using EasyNetQ;
using ObjectLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                Console.WriteLine("Podaj swój nick:");
                string nick = Console.ReadLine();
                Console.WriteLine(string.Format("Witaj, {0}!", nick));

                Receiver rec = new Receiver(bus);
                rec.Start();

                var input = "";
                while ((input = Console.ReadLine()) != "Quit")
                {
                    bus.Publish(new Message
                    {
                        Name = nick,
                        Text = input
                    });
                }
            }
        }       

    }
}
