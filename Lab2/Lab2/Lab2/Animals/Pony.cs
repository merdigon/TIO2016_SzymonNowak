using Lab2.Base_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2.Animals
{
    class Pony : Animal
    {
        bool IsMagic;

        public override string Sound()
        {
            return "IHAHA!";
        }

        public override string Trick()
        {
            return "Run on rinbow";
        }

        public override int CountLegs()
        {
            return 4;
        }
    }
}
