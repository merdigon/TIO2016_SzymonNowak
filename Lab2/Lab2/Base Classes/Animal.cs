using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2.Base_Classes
{
    class Animal
    {
        public string Name;
        float Weight;
        bool HaveFur;
        
        public virtual string Sound()
        {
            return "";
        }

        public virtual string Trick()
        {
            return "";
        }

        public virtual int CountLegs()
        {
            return 0;
        }
    }
}
