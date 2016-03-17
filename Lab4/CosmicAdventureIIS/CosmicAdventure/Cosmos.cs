using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CosmicAdventureDTO.DataTransferObjects;

namespace CosmicAdventure
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Cosmos : ICosmos
    {
        private List<StarSystem> _systems = new List<StarSystem>();

        public void InitializeGame()
        {
            Random rand = new Random();

            for(int i=0;i<5;i++)
            {
                _systems.Add(new StarSystem() 
                {
                    Gold = rand.Next(3000,7000),
                    BaseDistance = rand.Next(20,120),
                    MinShipPower = rand.Next(10,40),
                    Name = "KRVD651" + i
                });
            }
        }

        public Starship SendStarship(Starship starship, string systemName)
        {
            if (starship == null)
                return null;

            StarSystem system = _systems.Where(p => p.Name.Equals(systemName)).FirstOrDefault();
            if (system != null)
            {
                foreach (Person person in starship.Crew)
                {
                    person.Age += (2 * system.BaseDistance) / (starship.ShipPower <= 20 ? 12 : (starship.ShipPower > 30 ? 4 : 6));
                }
                starship.Crew = starship.Crew.Where(p => p.Age <= 90).ToList();

                if (starship.ShipPower >= system.MinShipPower)
                {
                    starship.Gold += system.Gold;
                    _systems = _systems.Where(p => !p.Name.Equals(system.Name)).ToList();
                }
            }
            else
            {
                starship.Crew = null;
            }
            return starship;
        }

        public StarSystem GetSystem()
        {
            if (_systems != null)
                return _systems.FirstOrDefault();
            else
                return null;
        }

        public Starship GetStarship(int money)
        {
            Random rand = new Random();

            Starship starship = new Starship();
            starship.Crew = new Person[]{
                new Person(){
                    Name ="Furiosa",
                    Age = 20,
                    Nick = "Fur"
                },
                new Person(){
                    Name = "Roger",
                    Age =20,
                    Nick = "Bro"
                },
                new Person(){
                    Name = "Carlos",
                    Age = 20,
                    Nick ="Mr. Dynamite"
                }
            }.ToList();

            starship.ShipPower = 
                (money > 1000 && money <= 3000 ? rand.Next(10,25) :
                (money > 3001 && money <= 10000 ? rand.Next(20,35) :
                (money > 10000 ? rand.Next(35,60) : rand.Next(1,10))));

            starship.Gold = 0;
            return starship;
        }
    }
}
