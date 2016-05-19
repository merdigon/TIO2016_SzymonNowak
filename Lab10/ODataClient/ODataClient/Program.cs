using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODataClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string serviceUri = "http://localhost:50179/";
            var container = new ODataClient.Default.Container(new Uri(serviceUri));

            //wyświetlenie gier
            var games = container.Games;
            games.ToList().ForEach(p => Console.WriteLine(
                string.Format("[{0}:{1}:{2}:{3}:{4}]", p.Id, p.Title, p.CreatorCompany, p.Year, p.AgeRate)
                ));

            //dodanie gry
            container.AddToGames(new CommonData.DTO.Game()
            {
                Title = "Fallout 3",
                CreatorCompany = "Bethesta",
                Year = 2008,
                AgeRate = 18,
                Id = 3
            });

            //wyświetlenie gier
            games = container.Games;
            games.ToList().ForEach(p => Console.WriteLine(
                string.Format("[{0}:{1}:{2}:{3}:{4}]", p.Id, p.Title, p.CreatorCompany, p.Year, p.AgeRate)
                ));

            //wyświetlenie listy koszulek
            var cardShirts = container.GetAvailableCardShirts();
            cardShirts.ToList().ForEach(p => Console.WriteLine(
                string.Format("[{0}:{1}]", p.Id, p.Name)
                ));

            //wyświetlenie sklepów
            var stores = container.Stores;
            stores.ToList().ForEach(p => Console.WriteLine(
                string.Format("[{0}:{1}:{2}]", p.Id, p.Name, p.Address)
                ));

            //usunięcie sklepu
            var storeToDelete = container.Stores.FirstOrDefault();
            if (storeToDelete != null)
            {
                container.Stores.Where(p => p.Id != storeToDelete.Id);
                container.SaveChanges();
            }
            
            //wyświetlenie sklepów
            stores = container.Stores;
            stores.ToList().ForEach(p => Console.WriteLine(
                string.Format("[{0}:{1}:{2}]", p.Id, p.Name, p.Address)
                ));

            Console.Read();
        }
    }
}
