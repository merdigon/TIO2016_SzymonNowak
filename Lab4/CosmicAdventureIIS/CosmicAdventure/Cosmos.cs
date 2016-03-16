using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ca = CosmicAdventureDTO.DataTransferObjects;

namespace CosmicAdventure
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Cosmos : ICosmos
    {
        private List<ca.System> _systems = new List<ca.System>();


    }
}
