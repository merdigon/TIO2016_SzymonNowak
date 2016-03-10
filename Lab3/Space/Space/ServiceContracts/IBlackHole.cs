using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Model_Struct.Space
{
    [ServiceContract]
    interface IBlackHole
    {
        [OperationContract]
        Starship PullStarship(Starship ship);

        [OperationContract]
        string UltimateAnswer();
    }
}
