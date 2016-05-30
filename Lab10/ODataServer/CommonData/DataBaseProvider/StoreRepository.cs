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

        public Task<int> Create(Store StoreToSave)
        {
            dbContext.Stores.Add(StoreToSave);
            return dbContext.SaveChangesAsync();
        }

        public Task<int> Update(Store StoreToUpdate)
        {
            dbContext.Entry(StoreToUpdate).State = EntityState.Modified;
            return dbContext.SaveChangesAsync();
        }

        public async Task<bool> Delete()
        {
            dbContext.Stores.RemoveRange(dbContext.Stores);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            Store store = dbContext.Stores.Find(id);
            if (store == null)
            {
                return false;
            }

            dbContext.Stores.Remove(store);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
