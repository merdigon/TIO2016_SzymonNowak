using LiteDB;
using LiteDBService.DBProvider.BaseObjects;
using LiteDBService.PersonReviewRepository.DTOModels;
using ModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDBService.PersonReviewRepository
{
    public class PersonRepository : RepositoryBase<Person, PersonDTO>
    {
        public PersonRepository()
            : base(@"C:\tmp\personsreviews", "persons") {}

        public Person ReadPersonWhereNameSurname(string name, string surname)
        {
            using (var db = new LiteDatabase(Conn))
            {
                var repository = db.GetCollection<Person>(CollectionName);
                return repository.Find(p => p.Surname.Equals(surname) && p.Name.Equals(name)).FirstOrDefault();
            }
        }

        public override Person Map(PersonDTO model)
        {
            if(model==null)
                return null;
            return new Person()
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname
            };
        }

        public override PersonDTO InverseMap(Person model)
        {
            if (model == null)
                return null;
            return new PersonDTO()
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname
            };
        }  
    }
}
