using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model_Struct.Space
{

    public class BlackHole : IBlackHole
    {
        public Starship PullStarship(Starship ship)
        {
            if (ship != null && ship.Captain != null && ship.Captain.Age <= 40)
            {
                foreach (Person p in ship.Crew)
                {
                    p.Age += 20;
                }
            }
            return ship;
        }

        public string UltimateAnswer()
        {
            return 42.ToString();
        }
    }
}
