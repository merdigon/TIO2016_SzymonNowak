using CosmosClients.ServiceClasses;
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
            Console.WriteLine("Aktualne złoto: {0} Wpisz za ile złota chcesz kupić statek", _client.GetNumberOfGold());
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
            string textToPrint, systemName;
            if ((textToPrint = _client.GetSystemInformation(out systemName)) == null)
                return;
            Console.WriteLine(textToPrint);

            if ((textToPrint = _client.GetNumberOfStarshipsInformation()) == null)
                return;
            Console.WriteLine(textToPrint);

            Console.WriteLine("Wybierz statek wpisując jego numer (albo wyjdź wpisując literę e):");
            Console.Write(_client.GetStarshipsInformation());

            string choosenOption = Console.ReadLine();
            if (choosenOption.Equals("e") || choosenOption.Equals("E"))
                return;

            int choosenStarhip;
            if (Int32.TryParse(choosenOption.ToString(), out choosenStarhip))
            {
                if (choosenStarhip <= _client.GetNumberOfStarships() && choosenStarhip > 0)
                {
                    _client.SendStarship(choosenStarhip, systemName);
                    Console.WriteLine("Statek pomyślnie wysłany w świat!");
                }
                else
                    Console.WriteLine("Brak statku dla podanej liczby!");
            }
            else
            {
                Console.WriteLine("Podana wartosc nie jest liczbą!");
            }
        }

        private void UserChooseD()
        {
            Console.WriteLine(_client.DidWeWin() ? "Wygrana!" : "Przegrana!");
            _gameOn = false;
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
