using CommonData.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonData.DataBaseProvider
{
    public class GameContext : DbContext
    {
        public GameContext()
            : base("GameContext") { }

        public DbSet<Game> Games { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<CardShirt> CardShirts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }
    }
}
