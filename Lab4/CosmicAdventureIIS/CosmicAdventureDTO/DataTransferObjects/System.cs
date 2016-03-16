using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CosmicAdventureDTO.DataTransferObjects
{
    [DataContract]
    public class System
    {
        [DataMember]
        string Name { get; set; }

        private int MinShipPower { get; set; }

        [DataMember]
        int BaseDistance { get; set; }

        private int Gold { get; set; }
    }
}
