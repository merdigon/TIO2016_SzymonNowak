using CommonData.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonData.DataBaseProvider
{
    public class CardShirtRepository : IRepository<CardShirt>
    {
        private GameContext dbContext;

        public CardShirtRepository() { dbContext = new GameContext(); }

        public IQueryable<CardShirt> Read()
        {
            try
            {
                return dbContext.CardShirts;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<CardShirt> Read(int id)
        {
            return dbContext.CardShirts.Where(p => p.Id == id);
        }

        public CardShirt Create(CardShirt CardShirtToSave)
        {
            dbContext.CardShirts.Add(CardShirtToSave);
            dbContext.SaveChanges();
            return CardShirtToSave;
        }

        public CardShirt Update(CardShirt CardShirtToUpdate)
        {
            dbContext.Entry(CardShirtToUpdate).State = EntityState.Modified;
            dbContext.SaveChanges();
            return CardShirtToUpdate;
        }

        public bool Delete()
        {
            dbContext.CardShirts.RemoveRange(dbContext.CardShirts);
            dbContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            CardShirt cardShirt = dbContext.CardShirts.Find(id);
            if (cardShirt == null)
            {
                return false;
            }

            dbContext.CardShirts.Remove(cardShirt);
            dbContext.SaveChanges();
            return true;
        }

    }
}
