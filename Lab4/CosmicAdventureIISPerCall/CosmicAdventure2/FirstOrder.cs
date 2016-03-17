using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CosmicAdventure2
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class FirstOrder : IFirstOrder
    {
        public int GetMoneyFromImperium()
        {
            return new Random().Next(3000, 5000);
        }
    }
}
