using CosmosClients.CosmosReference;
using CosmosClients.FirstOrderReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmosClients
{
    public class Client
    {
        List<Starship> _starships = new List<Starship>();
        bool _anySystem = true;
        int _gold = 1000;
        int _imperiumMoneyAskCount = 4;

        public int Gold
        {
            get
            {
                return _gold;
            }
        }

        private CosmosClient cosmosCl;
        private FirstOrderClient fOrderCl;

        public Client()
        {
            cosmosCl = new CosmosClient();
            fOrderCl = new FirstOrderClient();
            cosmosCl.InitializeGame();
        }

        public string GetMenuStats()
        {
            return "Money: " + _gold + ", requests: " + _imperiumMoneyAskCount;
        }

        public bool AskImperiumForGold()
        {
            if (fOrderCl == null)
                throw new GalacticException("Gate to first order was not initialized!");

            try
            {
                if (_imperiumMoneyAskCount > 0)
                {
                    _gold += fOrderCl.GetMoneyFromImperium();
                    _imperiumMoneyAskCount--;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new GalacticException("Error!", ex);
            }
        }

        public bool BuyShip(int money)
        {
            if (cosmosCl == null)
                throw new GalacticException("Gate to cosmos was not initialized!");

            try
            {
                if (money <= _gold)
                {
                    _starships.Add(cosmosCl.GetStarship(money));
                    _gold -= money;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new GalacticException("Error!", ex);
            }
        }
    }
}
