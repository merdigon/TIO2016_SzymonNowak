using LiteDBService.PersonReviewRepository;
using ModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFPersonReviewRepositoryService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class PersonReviewRepositoryService : IPersonReviewRepositoryService
    {
        PersonRepository PersonRepository { get; set; }

        ReviewRepository ReviewRepository { get; set; }

        public PersonReviewRepositoryService()
        {
            PersonRepository = new PersonRepository();
            ReviewRepository = new ReviewRepository();
        }

        public int CreatePerson(Person model)
        {
            return PersonRepository.Create(model);
        }

        public Person ReadPerson(int id)
        {
            return PersonRepository.Read(id);
        }

        public Person ReadPersonByNameAndSurname(string name, string surname)
        {
            return PersonRepository.ReadPersonWhereNameSurname(name, surname);
        }

        public List<Person> ReadPeople(int[] ids)
        {
            return PersonRepository.Read(ids);
        }

        public List<Person> ReadAllPeople()
        {
            return PersonRepository.ReadAll();
        }

        public Person UpdatePerson(Person model)
        {
            return PersonRepository.Update(model);
        }

        public bool DeletePerson(Person model)
        {
            return PersonRepository.Delete(model);
        }

        public int CreateReview(Review model)
        {
            return ReviewRepository.Create(model);
        }

        public Review ReadReview(int id)
        {
            return ReviewRepository.Read(id);
        }

        public List<Review> ReadReviews(int[] ids)
        {
            return ReviewRepository.Read(ids);
        }

        public List<Review> ReadAllReviews()
        {
            return ReviewRepository.ReadAll();
        }

        public List<Review> ReadReviewForMovie(int movieId)
        {
            return ReviewRepository.ReadWhereMovieID(movieId);
        }

        public List<Review> ReadReviewForUser(int userId)
        {
            return ReviewRepository.ReadWhereAuthorID(userId);
        }

        public Review UpdateReview(Review model)
        {
            return ReviewRepository.Update(model);
        }

        public bool DeleteReview(Review model)
        {
            return ReviewRepository.Delete(model);
        }
    }
}
