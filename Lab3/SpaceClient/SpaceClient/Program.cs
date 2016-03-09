using SpaceClient.BlackHoleService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            StarGate starGate = new StarGate();
            //b
            Console.WriteLine("BEFORE");
            Starship ship = starGate.CreateShipWithCrew();
            starGate.PresentCrew(ship);
            Console.WriteLine();
            //c
            Console.WriteLine("Ultimate Answer: " + starGate.UltimateAnswer());
            Console.WriteLine();
            ship = starGate.PullStarship(ship);
            //d
            Console.WriteLine("AFTER");
            starGate.PresentCrew(ship);
            Console.ReadLine();
        }
    }
}
