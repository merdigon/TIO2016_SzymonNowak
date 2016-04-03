using LiteDBService.MovieRepository;
using ModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFMovieRepository
{
    public class MovieRepositoryService : IMovieRepositoryService
    {
        MovieRepository MovieRepository { get; set; }

        public MovieRepositoryService()
        {
            MovieRepository = new MovieRepository();
        }

        public int CreateMovie(Movie model)
        {
            return MovieRepository.Create(model);
        }

        public Movie ReadMovie(int id)
        {
            return MovieRepository.Read(id);
        }

        public List<Movie> ReadMovies(int[] ids)
        {
            return MovieRepository.Read(ids);
        }

        public Movie UpdateMovie(Movie model)
        {
            return MovieRepository.Update(model);
        }

        public bool DeleteMovie(Movie model)
        {
            return MovieRepository.Delete(model);
        }
    }
}
