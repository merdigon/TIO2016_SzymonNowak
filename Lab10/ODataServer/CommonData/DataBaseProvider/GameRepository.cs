using CommonData.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonData.DataBaseProvider
{
    public class GameRepository : IRepository<Game>
    {
        private GameContext dbContext;

        public GameRepository() { dbContext = new GameContext(); }

        public IQueryable<Game> Read()
        {
            try
            {
                return dbContext.Games;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<Game> Read(int id)
        {
            return dbContext.Games.Where(p => p.Id == id);            
        }

        public Task<int> Create(Game GameToSave)
        {
            dbContext.Games.Add(GameToSave);
            return dbContext.SaveChangesAsync();
        }

        public Task<int> Update(Game GameToUpdate)
        {
            dbContext.Entry(GameToUpdate).State = EntityState.Modified;
            return dbContext.SaveChangesAsync();
        }

        public async Task<bool> Delete()
        {
            dbContext.Games.RemoveRange(dbContext.Games);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            Game game = dbContext.Games.Find(id);
            if (game == null)
            {
                return false;
            }

            dbContext.Games.Remove(game);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
