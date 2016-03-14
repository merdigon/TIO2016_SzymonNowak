using Lab2.Base_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Circus zalewski = new Circus();
            Zoo krakowskie = new Zoo();
            bool programShouldWork = true;
            bool shouldShowMenu = true;
            while (programShouldWork)
            {
                showMenu(shouldShowMenu);
                shouldShowMenu = true;
                char option = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (option)
                {
                    case 'a':
                        Console.WriteLine(zalewski.Show());
                        break;
                    case 'b':
                        Console.WriteLine(zalewski.AnimalsIntroduction());
                        break;
                    case 'c':
                        Console.WriteLine(krakowskie.Sounds());
                        break;
                    case 'd':
                        Console.WriteLine(krakowskie.Animals.FirstOrDefault().Name);
                        break;
                    case 'e':
                        Console.WriteLine(AllZooNames(krakowskie));
                        break;
                    case 'f':
                        programShouldWork = false;
                        break;
                    default:
                        shouldShowMenu = false;
                        break;
                }
            }
        }

        public static void showMenu(bool shouldShowMenu)
        {
            if (shouldShowMenu)
            {
                Console.WriteLine("Wybierz opcje programu:");
                Console.WriteLine("a ) Prezentacja zwierząt w cyrku Zalewskim");
                Console.WriteLine("b ) Obejrzenie programu cyrku Zalewskim");
                Console.WriteLine("c ) Posłuchanie dźwięków Zoo Krakowskiego");
                Console.WriteLine("d ) Wyświetla imię pierwszego znalezionego futrzaka w Zoo");
                Console.WriteLine("e ) Wyświetla wszystkie imiona zwierząt w Cyrku");
                Console.WriteLine("f ) Zakończenie programu");
            }
        }

        public static string AllZooNames(Zoo zoo)
        {
            string result = string.Empty;
            foreach(Animal anim in zoo.Animals)
            {
                result += anim.Name + ", ";
            }
            return result;
        }
    }
}
