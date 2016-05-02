using ObjectLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProvidersLibrary.PGProvider
{
    class MuseumInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MuseumContext>
    {
        protected override void Seed(MuseumContext context)
        {
            var artists = new List<Artist>
            {
                new Artist() { ArtistName = "Jan", ArtistSurname="Matejko"},
                new Artist() {ArtistName = "Mary", ArtistSurname="Beale"}
            };
            artists.ForEach(i => context.Artists.Add(i));
            context.SaveChanges();

            var paintings = new List<Painting>()
            {
                new Painting() { Title="Bitwa pod Grunwaldem", Year=1878 },
                new Painting() { Title="Charles Beale", Year=1680 }
            };
            paintings.ForEach(g => context.Paintings.Add(g));
            context.SaveChanges();
        }
    }
}
