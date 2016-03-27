using CosmosClients.CosmosReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmosClients.ServiceClasses
{
    public class GameStats
    {
        List<Starship> _starships = new List<Starship>();

        public List<Starship> Starships
        {
            get
            {
                return _starships;
            }
            set
            {
                _starships = value;
            }
        }

        bool _anySystem = true;
        public bool AnySystem
        {
            get
            {
                return _anySystem;
            }
            set
            {
                _anySystem = value;
            }
        }

        int _gold = 1000;
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

        int _imperiumMoneyAskCount = 4;
        public int ImperiumMoneyAskCount
        {
            get
            {
                return _imperiumMoneyAskCount;
            }
            set
            {
                _imperiumMoneyAskCount = value;
            }
        }
    }
}
