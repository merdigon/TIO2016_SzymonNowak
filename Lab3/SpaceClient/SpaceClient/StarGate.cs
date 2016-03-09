using SpaceClient.BlackHoleService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceClient
{
    public class StarGate
    {
        BlackHoleClient StarGateConn { get; set; }

        public StarGate()
        {
            StarGateConn = new BlackHoleClient();
        }

        public Starship CreateShipWithCrew()
        {
            Starship ship = new Starship();
            ship.Captain = new Person() { Name = "Jan Nowak", Age = 35 };

            ship.Crew = new Person[]{
                new Person() { Name = "Szymon Gruszka", Age = 20 },
                new Person() { Name = "Mieczyslaw Kapusta", Age = 56 },
                new Person() { Name = "Tomasz Kirk", Age = 41 },
                new Person() { Name = "Arkadiusz Spock", Age = 31 },
                new Person() { Name = "Mateusz McCoy", Age = 13 }
            };
            return ship;
        }

        public void PresentCrew(Starship ship)
        {
            Console.WriteLine("Captain:");
            if(ship.Captain!=null)
                Console.WriteLine(" - " + ship.Captain.Name + ": age " + ship.Captain.Age);
            else
                Console.WriteLine("   NO CAPTAIN!");

            Console.WriteLine("Crew:");
            foreach (Person p in ship.Crew)
                Console.WriteLine(" - " + p.Name + ": age " + p.Age);
        }

        public Starship PullStarship(Starship ship)
        {
            if (StarGateConn != null)
                return StarGateConn.PullStarship(ship);
            return null;
        }

        public string UltimateAnswer()
        {
            if (StarGateConn != null)
                return StarGateConn.UltimateAnswer();
            return string.Empty;
        }
    }
}
