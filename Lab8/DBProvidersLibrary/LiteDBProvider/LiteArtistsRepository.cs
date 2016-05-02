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
    public class LiteArtistsRepository : IArtistsRepository
    {

        public LiteArtistsRepository()
        {
            _collectionName = "artist";
            _conn = @"C:\tmp\museum";
        }

        //CONFIGURATION PART

        private readonly string _conn;

        private readonly string _collectionName;

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
        
        public Artist Read(int id)
        {
            using (var db = new LiteDatabase(_conn))
            {
                var repository = db.GetCollection<Artist>(_collectionName);
                var result = repository.FindById(id);
                return result;
            }
        }

        public IList<Artist> Read()
        {
            using (var db = new LiteDatabase(_conn))
            {
                IList<Artist> objects = new List<Artist>();
                var repository = db.GetCollection<Artist>(_collectionName);
                foreach (var result in repository.FindAll())
                {
                    objects.Add(result);
                }
                return objects;
            }
        }

        public Artist Update(Artist model)
        {
            using (var db = new LiteDatabase(_conn))
            {
                var repository = db.GetCollection<Artist>(_collectionName);
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
                var repository = db.GetCollection<Artist>(_collectionName);
                return repository.Delete(id);
            }
        }

        public Artist Create(Artist objectToSave)
        {
            using (var db = new LiteDatabase(_conn))
            {
                var repository = db.GetCollection<Artist>(_collectionName);
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
                var repository = db.GetCollection<Artist>(_collectionName);
                foreach (Artist artist in repository.FindAll())
                {
                    repository.Delete(artist.Id);
                }
                return true;
            }
        }
    }
}
