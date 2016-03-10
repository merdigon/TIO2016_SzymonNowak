using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Model_Struct.Space
{
    [DataContract]
    public class Starship
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Person Captain { get; set; }

        [DataMember]
        public List<Person> Crew { get; set; }
    }
}