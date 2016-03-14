using Lab2.Base_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2.Animals
{
    class Ant : Animal
    {
        bool IsQueen;

        public override string Sound()
        {
            return "KRIKRI!";
        }

        public override string Trick()
        {
            return "Uplift things 100 times heavier than itself";
        }

        public override int CountLegs()
        {
            return 6;
        }
    }
}
