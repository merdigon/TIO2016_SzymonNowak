using ObjectLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProvidersLibrary.PGProvider
{
    public class MuseumContext : DbContext
    {
        public MuseumContext()
            : base("MuseumContext")        {        }

        public DbSet<Painting> Paintings { get; set; }
        public DbSet<Artist> Artists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }
    }
}
