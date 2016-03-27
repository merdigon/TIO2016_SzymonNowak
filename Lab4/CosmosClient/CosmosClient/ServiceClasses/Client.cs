using CosmosClients.CosmosReference;
using CosmosClients.FirstOrderReference;
using System;
using System.ServiceModel;
using System.Text;

namespace CosmosClients.ServiceClasses
{
    public class Client
    {
        private CosmosClient cosmosCl;
        private FirstOrderClient fOrderCl;
        private GameStats gameStats;

        public Client()
        {
            try
            {
                cosmosCl = new CosmosClient();
                fOrderCl = new FirstOrderClient();
                gameStats = new GameStats();
                cosmosCl.InitializeGame();
            }
            catch (EntryPointNotFoundException eex)
            {
                throw new GalacticException("Brak dostępu do gwiezdnych wrót: " + eex.Message);
            }
            catch (ServerTooBusyException sex)
            {
                throw new GalacticException("Gwiezdne wrota są zajęte, podróżniku: " + sex.Message);
            }
            catch (Exception ex)
            {
                throw new GalacticException("Nieznany błąd podczas inicjalizacji gwiezdnych wrót: " + ex.Message);
            }
        }


        public bool AskImperiumForGold()
        {
            if (fOrderCl == null)
                throw new GalacticException("Gate to first order was not initialized!");

            try
            {
                if (gameStats.ImperiumMoneyAskCount > 0)
                {
                    gameStats.Gold += fOrderCl.GetMoneyFromImperium();
                    gameStats.ImperiumMoneyAskCount--;
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
                if (money <= gameStats.Gold)
                {
                    gameStats.Starships.Add(cosmosCl.GetStarship(money));
                    gameStats.Gold -= money;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new GalacticException("Error!", ex);
            }
        }

        public bool DidWeWin()
        {
            return !gameStats.AnySystem;
        }

        public void EndStarshipSending()
        {
            if (gameStats.Starships.Count == 0)
                gameStats.AnySystem = false;
        }

        public string GetMenuStats()
        {
            return "Money: " + gameStats.Gold + ", requests: " + gameStats.ImperiumMoneyAskCount;
        }

        public int GetNumberOfGold()
        {
            return gameStats.Gold;
        }
        public int GetNumberOfStarships()
        {
            return gameStats.Starships.Count;
        }

        public string GetNumberOfStarshipsInformation()
        {
            if (gameStats.Starships.Count == 0)
            {
                EndStarshipSending();
                Console.WriteLine("Hangar jest pusty!");
                return null;
            }
            return "Statków gotowych do podróży: " + GetNumberOfStarships() + ".";
        }

        public string GetStarshipsInformation()
        {
            StringBuilder strBuild = new StringBuilder();
            int i = 1;
            foreach (Starship ship in gameStats.Starships)
            {
                strBuild.Append(i + ". ");
                strBuild.Append(ship.ShipPower + ", ");
                foreach (Person person in ship.Crew)
                {
                    strBuild.Append(person.Name + " ");
                    strBuild.Append(person.Age + ", ");
                }
                strBuild.AppendLine();
                i++;
            }
            return strBuild.ToString();
        }

        public string GetSystemInformation()
        {
            string result;
            return GetSystemInformation(out result);
        }

        public string GetSystemInformation(out string systemName)
        {
            if (cosmosCl == null)
                throw new GalacticException("Gate to cosmos was not initialized!");

            try
            {
                StarSystem starSys;
                systemName = null;
                if ((starSys = cosmosCl.GetSystem()) == null)
                {
                    EndStarshipSending();
                    Console.WriteLine("Brak systemu!");
                    return null;
                }
                systemName = starSys.Name;
                return "System " + starSys.Name + ", odleglość " + starSys.BaseDistance + ".";
            }
            catch (Exception ex)
            {
                throw new GalacticException("Error!", ex);
            }
        }

        public void SendStarship(int index, string systemName)
        {
            if (cosmosCl == null)
                throw new GalacticException("Gate to cosmos was not initialized!");

            try
            {
                Starship returnedStarship = cosmosCl.SendStarship(gameStats.Starships[index-1], systemName);
                gameStats.Starships.RemoveAt(index-1);

                if (returnedStarship.Gold != 0)
                {
                    gameStats.Gold += returnedStarship.Gold;
                    returnedStarship.Gold = 0;
                }

                if (returnedStarship.Crew.Length > 0)
                    gameStats.Starships.Add(returnedStarship);
            }
            catch (Exception ex)
            {
                throw new GalacticException("Error!", ex);
            }
        }
    }
}