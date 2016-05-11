using ObjectLibrary.DTO;
using ObjectLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProvidersLibrary.PGProvider
{
    public class PGArtistsRepository : IArtistsRepository
    {
        private MuseumContext dbContext;

        public PGArtistsRepository() { dbContext = new MuseumContext(); }

        public IList<Artist> Read()
        {
            return dbContext.Artists.ToList();
        }

        public Artist Read(int id)
        {
            return dbContext.Artists.Find(id);            
        }

        public Artist Create(Artist artistToSave)
        {
            dbContext.Artists.Add(artistToSave);
            dbContext.SaveChanges();
            return artistToSave;
        }

        public Artist Update(Artist artistToUpdate)
        {
            dbContext.Entry(artistToUpdate).State = EntityState.Modified;
            dbContext.SaveChanges();
            return artistToUpdate;
        }

        public bool Delete()
        {
            dbContext.Artists.RemoveRange(dbContext.Artists);
            dbContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            Artist artist = dbContext.Artists.Find(id);
            if (artist == null)
            {
                return false;
            }

            dbContext.Artists.Remove(artist);
            dbContext.SaveChanges();
            return true;
        }
    }
}
