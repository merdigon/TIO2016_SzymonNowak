using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model_Struct.Space
{
    public class Starship
    {
        public string Name { get; set; }
        public Person Captain { get; set; }
        public List<Person> Crew { get; set; }
        public void PresentCrew()
        {
            Console.WriteLine("Captain: " + Captain.Name);
            Console.WriteLine("Crew:");
            foreach (Person p in Crew)
            {
                Console.WriteLine(p.Name);
            }
        }
    }
}