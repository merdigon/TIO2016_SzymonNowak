using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CosmicAdventureDTO.DataTransferObjects
{
    [DataContract]
    public class StarSystem
    {
        [DataMember]
        public string Name { get; set; }

        private int _minShipPower;

        public int MinShipPower
        {
            get
            {
                return _minShipPower;
            }
            set
            {
                _minShipPower = value;
            }
        }

        [DataMember]
        public int BaseDistance { get; set; }

        
        private int _gold;

        public int Gold
        {
            get
            {
                return _gold;
            }
            set
            {
                _gold = value;
            }
        }
    }
}
