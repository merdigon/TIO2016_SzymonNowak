using Lab2.Base_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2.Animals
{
    class Giraffe : Animal
    {
        public override string Sound()
        {
            return "FTHRU";
        }

        public override string Trick()
        {
            return "That neck...";
        }

        public override int CountLegs()
        {
            return 4;
        }
    }
}
