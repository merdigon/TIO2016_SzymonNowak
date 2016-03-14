using Lab2.Base_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2.Animals
{
    class Elephant : Animal
    {
        public override string Sound()
        {
            return "TRUTUTU!";
        }

        public override string Trick()
        {
            return "Can make himself a shover wth his trunk";
        }

        public override int CountLegs()
        {
            return 4;
        }
    }
}
