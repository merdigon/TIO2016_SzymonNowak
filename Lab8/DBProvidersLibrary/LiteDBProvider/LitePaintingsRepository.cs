using LiteDB;
using ObjectLibrary.DTO;
using ObjectLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProvidersLibrary.LiteDBProvider
{
    public class LitePaintingsRepository : IPaintingsRepository
    {

        public LitePaintingsRepository()
        {
            _collectionName = "painting";
            _conn = @"C:\tmp\museum";
        }

        //CONFIGURATION PART

        private readonly string _conn;

        private readonly string _collectionName;

        public LitePaintingsRepository(string connectionString, string collectionName)
        {
        }

        protected string Conn
        {
            get
            {
                return _conn;
            }
        }

        protected string CollectionName
        {
            get
            {
                return _collectionName;
            }
        }

        //CRUD PART
        
        public Painting Read(int id)
        {
            using (var db = new LiteDatabase(_conn))
            {
                var repository = db.GetCollection<Painting>(_collectionName);
                var result = repository.FindById(id);
                return result;
            }
        }

        public IList<Painting> Read()
        {
            using (var db = new LiteDatabase(_conn))
            {
                IList<Painting> objects = new List<Painting>();
                var repository = db.GetCollection<Painting>(_collectionName);
                foreach (var result in repository.FindAll())
                {
                    objects.Add(result);
                }
                return objects;
            }
        }

        public Painting Update(Painting model)
        {
            using (var db = new LiteDatabase(_conn))
            {
                var repository = db.GetCollection<Painting>(_collectionName);
                if (repository.Update(model))
                    return model;
                else
                    return null;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(_conn))
            {
                var repository = db.GetCollection<Painting>(_collectionName);
                return repository.Delete(id);
            }
        }

        public Painting Create(Painting objectToSave)
        {
            using (var db = new LiteDatabase(_conn))
            {
                var repository = db.GetCollection<Painting>(_collectionName);
                if (repository.FindById(objectToSave.Id) != null)
                    repository.Update(objectToSave);
                else
                    repository.Insert(objectToSave);
            }
            return objectToSave;
        }

        public bool Delete()
        {
            using (var db = new LiteDatabase(_conn))
            {
                var repository = db.GetCollection<Painting>(_collectionName);
                foreach (Painting painting in repository.FindAll())
                {
                    repository.Delete(painting.Id);
                }
                return true;
            }
        }
    }
}
