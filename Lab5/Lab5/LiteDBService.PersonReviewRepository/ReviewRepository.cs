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
    public class ReviewRepository : RepositoryBase<Review, ReviewDTO>
    {
        public ReviewRepository()
            : base(@"C:\tmp\personsreviews", "reviews") {}

        public List<Review> ReadWhereMovieID(int movieID)
        {
            using (var db = new LiteDatabase(Conn))
            {
                List<Review> movies = new List<Review>();
                var repository = db.GetCollection<ReviewDTO>(CollectionName);
                foreach (var result in repository.FindAll())
                {
                    if(result.MovieId == movieID)
                        movies.Add(Map(result));
                }
                return movies;
            }
        }

        public List<Review> ReadWhereAuthorID(int userID)
        {
            using (var db = new LiteDatabase(Conn))
            {
                List<Review> movies = new List<Review>();
                var repository = db.GetCollection<ReviewDTO>(CollectionName);
                foreach (var result in repository.FindAll())
                {
                    if (result.AuthorID == userID)
                        movies.Add(Map(result));
                }
                return movies;
            }
        }

        public override Review Map(ReviewDTO model)
        {
            if (model == null)
                return null;
            var authorRepo = new PersonRepository();
            Person author = authorRepo.Read(model.AuthorID);
            return new Review()
            {
                Author = author,
                Content = model.Content,
                Id = model.Id,
                MovieId = model.MovieId,
                Score = model.Score
            };
        }

        public override ReviewDTO InverseMap(Review model)
        {
            if (model == null)
                return null;
            return new ReviewDTO()
            {
                AuthorID = (model.Author == null ? 0 : model.Author.Id),
                Content = model.Content,
                Id = model.Id,
                MovieId = model.MovieId,
                Score = model.Score
            };
        }
    }
}
