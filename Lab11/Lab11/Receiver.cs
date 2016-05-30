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
    public class Receiver
    {
        public IBus Bus { get; set; }
        public int Id { get; set; }

        public Receiver(IBus bus)
        {
            this.Bus = bus;
            Random rnd = new Random();
            Id = rnd.Next(1000000000);
        }

        public void Start()
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerAsync();
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            Bus.Subscribe<Message>(Id.ToString(), HandleTextMessage);
        }

        static void HandleTextMessage(Message textMessage)
        {
            Console.WriteLine(string.Format("<{0}>: {1}", textMessage.Name, textMessage.Text));
        }
    }
}
