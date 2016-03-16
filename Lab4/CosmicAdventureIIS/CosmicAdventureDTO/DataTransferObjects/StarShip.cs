using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CosmicAdventureDTO.DataTransferObjects
{
    [DataContract]
    public class Starship
    {
        [DataMember]
        public List<Person> Crew { get; set; }

        [DataMember]
        public int Gold { get; set; }

        [DataMember]
        public int ShipPower { get; set; }
    }
}
