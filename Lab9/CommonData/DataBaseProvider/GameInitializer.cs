using CommonData.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonData.DataBaseProvider
{
    class GameInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<GameContext>
    {
        protected override void Seed(GameContext context)
        {
            var games = new List<Game>
            {
                new Game() { AgeRate = 18, CreatorCompany="2K", Title="Bioshock", Year=2007},
                new Game() { AgeRate = 18, CreatorCompany="Arkane Studio", Title="Dishonored", Year=2012 }
            };
            games.ForEach(i => context.Games.Add(i));
            context.SaveChanges();

            var stores = new List<Store>()
            {
                new Store() { Name="Empik", Address="Galeria Krakowska" },
                new Store() { Name="Saturn", Address="Galeria Krakowska" }
            };
            stores.ForEach(g => context.Stores.Add(g));
            context.SaveChanges();
        }
    }
}
