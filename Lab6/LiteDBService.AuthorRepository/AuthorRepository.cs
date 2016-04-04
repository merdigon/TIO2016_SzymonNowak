using LiteDB;
using LiteDBService.DBProvider;
using LiteDBService.DBProvider.BaseObjects;
using LiteDBService.AuthorRepository.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLib;

namespace LiteDBService.AuthorRepository
{
    public class AuthorRepository : RepositoryBase<Author, AuthorDTO>
    {        
        public AuthorRepository()
            : base(@"C:\tmp\author", "authors") { }

        public override Author Map(AuthorDTO model)
        {
            if(model==null)
                return null;
            return new Author()
            {
                Id = model.Id,
                AuthorName = model.AuthorName,
                AuthorSurname = model.AuthorSurname
            };
        }

        public override AuthorDTO InverseMap(Author model)
        {
            if (model == null)
                return null;
            return new AuthorDTO()
            {
                Id = model.Id,
                AuthorName = model.AuthorName,
                AuthorSurname = model.AuthorSurname
            };
        }
    }
}
