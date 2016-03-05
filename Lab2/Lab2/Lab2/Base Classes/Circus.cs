using Lab2.Animals;
using Lab2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2.Base_Classes
{
    class Circus : ICircus
    {
        List<Animal> Animals;
        string Name;

        public Circus()
        {
            Animals = new List<Animal>();
            Animals.Add(new Giraffe() { Name = "Szalony" });
            Animals.Add(new Ant() { Name = "Gozny" });
            Animals.Add(new Elephant() { Name = "Msciciel" });
            Animals.Add(new Cat() { Name = "Gatorex" });
            Animals.Add(new Pony() { Name = "Zebisty" });
            Animals.Add(new Giraffe() { Name = "Spike" });
            Animals.Add(new Ant() { Name = "Bonio" });
            Animals.Add(new Elephant() { Name = "Trabalski" });
            Animals.Add(new Cat(){ Name = "Kotorex" });
            Animals.Add(new Pony(){ Name = "Little" });
        }

        public string AnimalsIntroduction()
        {
            string result = string.Empty;
            foreach (Animal anim in Animals)
            {
                result += anim.Sound() +" ";
            }
            return result;
        }

        public string Show()
        {
            string result = string.Empty;
            foreach (Animal anim in Animals)
            {
                result += anim.Trick() + " ";
            }
            return result;
        }

        public int Patter(int howMuch)
        {
            int result = 0;
            foreach (Animal anim in Animals)
            {
                result += anim.CountLegs();
            }
            return result*howMuch;
        }
    }
}
