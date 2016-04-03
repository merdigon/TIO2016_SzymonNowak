using ModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFMovieRepositoryService
{
   [ServiceContract]
    public interface IMovieRepositoryService
    {
        [OperationContract]
        int CreateMovie(Movie model);

        [OperationContract]
        Movie ReadMovie(int id);

        [OperationContract]
        List<Movie> ReadMovies(int[] ids);


        [OperationContract]
        List<Movie> ReadAllMovies();

        [OperationContract]
        Movie UpdateMovie(Movie model);

        [OperationContract]
        bool DeleteMovie(Movie model);
    }
}
