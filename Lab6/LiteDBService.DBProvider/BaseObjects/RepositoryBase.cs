using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDBService.DBProvider.BaseObjects
{
    public abstract class RepositoryBase<T, Y> where T : RepositoryModelBase, new() where Y : BaseDTO, new()
    {
        //CONFIGURATION PART

        private readonly string _conn;

        private readonly string _collectionName;

        public RepositoryBase(string connectionString, string collectionName)
        {
            _collectionName = collectionName;
            _conn = connectionString;
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

        public int Create(T model)
        {
            using (var db = new LiteDatabase(_conn))
            {
                var dbObject = InverseMap(model);

                var repository = db.GetCollection<Y>(_collectionName);
                if (repository.FindById(model.Id) != null)
                    repository.Update(dbObject);
                else
                    repository.Insert(dbObject);

                return dbObject.Id;
            }
        }

        public T Read(int id)
        {
            using (var db = new LiteDatabase(_conn))
            {
                var repository = db.GetCollection<Y>(_collectionName);
                var result = repository.FindById(id);
                return Map(result);
            }
        }

        public List<T> ReadAll()
        {
            using (var db = new LiteDatabase(_conn))
            {
                List<T> objects = new List<T>();
                var repository = db.GetCollection<Y>(_collectionName);
                foreach (var result in repository.FindAll())
                {
                    objects.Add(Map(result));
                }
                return objects;
            }
        }

        public List<T> Read(int[] ids)
        {
            using (var db = new LiteDatabase(_conn))
            {
                List<T> objects = new List<T>();
                var repository = db.GetCollection<Y>(_collectionName);
                foreach (int id in ids)
                {
                    var result = repository.FindById(id);
                    objects.Add(Map(result));
                }
                return objects;
            }
        }

        public T Update(T model)
        {
            using (var db = new LiteDatabase(_conn))
            {
                var dbObject = InverseMap(model);

                var repository = db.GetCollection<Y>(_collectionName);
                if (repository.Update(dbObject))
                    return Map(dbObject);
                else
                    return null;
            }
        }

        public bool Delete(T model)
        {
            using (var db = new LiteDatabase(_conn))
            {
                var repository = db.GetCollection<Y>(_collectionName);
                return repository.Delete(model.Id);
            }
        }

        //MAP-INVERSEMAP PART

        public abstract T Map(Y model);

        public abstract Y InverseMap(T model);            
    }
}
