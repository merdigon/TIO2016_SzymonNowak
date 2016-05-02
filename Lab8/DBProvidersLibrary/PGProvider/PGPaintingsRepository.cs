using ObjectLibrary.DTO;
using ObjectLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProvidersLibrary.PGProvider
{
    public class PGPaintingsRepository : IPaintingsRepository
    {
        private MuseumContext dbContext;

        public PGPaintingsRepository() { dbContext = new MuseumContext(); }

        public IList<Painting> Read()
        {
            return dbContext.Paintings.ToList();
        }

        public Painting Read(int id)
        {
            return dbContext.Paintings.Find(id);            
        }

        public Painting Create(Painting paintingToSave)
        {
            dbContext.Paintings.Add(paintingToSave);
            dbContext.SaveChanges();
            return paintingToSave;
        }

        public Painting Update(Painting paintingToUpdate)
        {
            dbContext.Entry(paintingToUpdate).State = EntityState.Modified;
            dbContext.SaveChanges();
            return paintingToUpdate;
        }

        public bool Delete()
        {
            dbContext.Paintings.RemoveRange(dbContext.Paintings);
            dbContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            Painting painting = dbContext.Paintings.Find(id);
            if (painting == null)
            {
                return false;
            }

            dbContext.Paintings.Remove(painting);
            dbContext.SaveChanges();
            return true;
        }
    }
}
