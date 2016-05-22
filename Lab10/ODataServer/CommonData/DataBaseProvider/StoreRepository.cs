using CommonData.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonData.DataBaseProvider
{
    public class StoreRepository : IRepository<Store>
    {
        private GameContext dbContext;

        public StoreRepository() { dbContext = new GameContext(); }

        public IQueryable<Store> Read()
        {
            return dbContext.Stores;
        }

        public IQueryable<Store> Read(int id)
        {
            return dbContext.Stores.Where(p => p.Id == id);            
        }

        public Store Create(Store StoreToSave)
        {
            dbContext.Stores.Add(StoreToSave);
            dbContext.SaveChanges();
            return StoreToSave;
        }

        public Store Update(Store StoreToUpdate)
        {
            dbContext.Entry(StoreToUpdate).State = EntityState.Modified;
            dbContext.SaveChanges();
            return StoreToUpdate;
        }

        public bool Delete()
        {
            dbContext.Stores.RemoveRange(dbContext.Stores);
            dbContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            Store store = dbContext.Stores.Find(id);
            if (store == null)
            {
                return false;
            }

            dbContext.Stores.Remove(store);
            dbContext.SaveChanges();
            return true;
        }
    }
}
