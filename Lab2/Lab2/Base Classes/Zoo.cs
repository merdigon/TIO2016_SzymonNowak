using Lab2.Animals;
using Lab2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2.Base_Classes
{
    class Zoo : IZoo
    {
        public List<Animal> Animals;
        string Name;

        public Zoo()
        {
            Animals = new List<Animal>();
            Animals.Add(new Ant() { Name = "Bruno" });
            Animals.Add(new Elephant() { Name = "Rex" });
            Animals.Add(new Pony() { Name = "Mieczyslaw" });
            Animals.Add(new Ant() { Name = "Kamil" });
            Animals.Add(new Elephant() { Name = "Jan" });
            Animals.Add(new Pony() { Name = "Szymon" });
            Animals.Add(new Ant() { Name = "Brodaty" });
            Animals.Add(new Elephant() { Name = "Flufy" });
            Animals.Add(new Pony() { Name = "Rozek" });
        }

        public string Sounds()
        {
            string result = string.Empty;
            foreach (Animal anim in Animals)
            {
                result += anim.Sound() + " ";
            }
            return result;
        }
    }
}
