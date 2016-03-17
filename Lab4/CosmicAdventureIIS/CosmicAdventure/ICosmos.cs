using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CosmicAdventureDTO.DataTransferObjects;

namespace CosmicAdventure
{
    [ServiceContract]
    public interface ICosmos
    {
        [OperationContract]
        void InitializeGame();

        [OperationContract]
        Starship SendStarship(Starship starship, string systemName);
            
        [OperationContract]
        StarSystem GetSystem();

        [OperationContract]
        Starship GetStarship(int money);
    }
}
