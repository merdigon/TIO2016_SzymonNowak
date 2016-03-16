using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CosmicAdventureDTO.DataTransferObjects
{
    [DataContract]
    public class Person
    {
        [DataMember]
        string Name { get; set; }

        [DataMember]
        string Nick { get; set; }

        [DataMember]
        float Age { get; set; }
    }
}
