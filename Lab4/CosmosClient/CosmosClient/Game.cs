using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmosClients
{
    public class Game
    {
        Client _client;
        bool _gameOn = true;

        public Game()
        {
            _client = new Client();
        }

        public void Start()
        {
            while (_gameOn)
            {
                try
                {
                    Console.WriteLine(_client.GetMenuStats());
                    Console.WriteLine(BuildMenuOptions());

                    char choice = Console.ReadKey().KeyChar;
                    Console.WriteLine();

                    switch (choice)
                    {
                        case 'a':
                            UserChooseA();
                            break;
                        case 'b':
                            UserChooseB();
                            break;
                        case 'c':
                            UserChooseC();
                            break;
                        case'd':
                            UserChooseD();
                            break;
                        default:
                            Console.WriteLine("Błędny wybór - spróbuj jeszcze raz!");
                            break;
                    }
                }
                catch (GalacticException gEx)
                {
                    if(gEx!=null)
                    {
                        if (gEx.InnerException != null)
                            Console.WriteLine(gEx.Message + ": " + gEx.InnerException.Message);
                        else
                            Console.WriteLine(gEx.Message);
                    }
                }
            }
        }

        private void UserChooseA()
        {
            if (_client.AskImperiumForGold())
                Console.WriteLine("Imperium wysłuchało Twojej prośby!");
            else
                Console.WriteLine("Niestety, imperium nie wysłucha Twoich błagań");
        }

        private void UserChooseB()
        {
            int moneyValue;
            Console.WriteLine("Aktualne złoto: {0} Wpisz za ile złota chcesz kupić statek", _client.Gold);
            if (Int32.TryParse(Console.ReadLine(), out moneyValue))
            {
                if (_client.BuyShip(moneyValue))
                {
                    Console.WriteLine("Statek został kupiony!");
                    return;
                }
            }
            Console.WriteLine("Wprowadzono złą kwotę!");
        }

        private void UserChooseC()
        {

        }

        private void UserChooseD()
        {

        }

        private string BuildMenuOptions()
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.AppendLine("a) Poproś imperium o złoto");
            strBuilder.AppendLine("b) Kup statek za złoto");
            strBuilder.AppendLine("c) Wyślij statek do systemu");
            strBuilder.AppendLine("d) Zakoncz gre");
            return strBuilder.ToString();
        }
    }
}
