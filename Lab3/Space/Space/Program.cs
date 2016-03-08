using Model_Struct.Space;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;

namespace Space
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri address = new Uri("http://localhost:9019/BlackHole");
            ServiceHost selfHost = new ServiceHost(typeof(BlackHole), address);

            try
            {
                selfHost.AddServiceEndpoint(typeof(IBlackHole), new WSHttpBinding(), "BlackHoleServiceEndpoint");
                ServiceMetadataBehavior smd = new ServiceMetadataBehavior();
                smd.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smd);

                selfHost.Open();
                Console.WriteLine("Server is working...");
                Console.ReadLine();

                selfHost.Close();
            }
            catch (CommunicationException ex)
            {
                Console.WriteLine("Pojawil się blad komunikacji o wiadomosci: " + ex.Message);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Pojawil się nieobslugiwany blad o wiadomosci: " + ex.Message);
                Console.ReadLine();
            }
            finally
            {
                if (selfHost != null)
                    selfHost.Abort();
            }
        }
    }
}
