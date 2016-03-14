using Lab2.Base_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2.Animals
{
    class Cat : Animal
    {
        string Color;
        public override string Sound()
        {
            return "MEOW!";
        }

        public override string Trick()
        {
            return "Have 9 lifes";
        }

        public override int CountLegs()
        {
            return 4;
        }
    }
}
