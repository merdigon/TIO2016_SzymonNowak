using LiteDB;
using LiteDBService.DBProvider;
using LiteDBService.DBProvider.BaseObjects;
using LiteDBService.MovieRepository.DTOModels;
using ModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDBService.MovieRepository
{
    public class MovieRepository : RepositoryBase<Movie, MovieDTO>
    {        
        public MovieRepository()
            : base(@"C:\tmp\movie", "movies") {}

        public override Movie Map(MovieDTO model)
        {
            if(model==null)
                return null;
            return new Movie()
            {
                Id = model.Id,
                Title = model.Title,
                ReleaseYear = model.ReleaseYear
            };
        }

        public override MovieDTO InverseMap(Movie model)
        {
            if (model == null)
                return null;
            return new MovieDTO()
            {
                Id = model.Id,
                Title = model.Title,
                ReleaseYear = model.ReleaseYear
            };
        }
    }
}
