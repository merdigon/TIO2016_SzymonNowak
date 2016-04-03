using ModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFPersonReviewRepositoryService
{
    [ServiceContract]
    public interface IPersonReviewRepositoryService
    {
        [OperationContract]
        int CreatePerson(Person model);

        [OperationContract]
        Person ReadPerson(int id);

        [OperationContract]
        List<Person> ReadPeople(int[] ids);

        [OperationContract]
        List<Person> ReadAllPeople();

        [OperationContract]
        Person UpdatePerson(Person model);

        [OperationContract]
        bool DeletePerson(Person model);

        [OperationContract]
        int CreateReview(Review model);

        [OperationContract]
        Review ReadReview(int id);

        [OperationContract]
        Person ReadPersonByNameAndSurname(string name, string surname);

        [OperationContract]
        List<Review> ReadReviews(int[] ids);

        [OperationContract]
        List<Review> ReadAllReviews();

        [OperationContract]
        List<Review> ReadReviewForMovie(int movieId);

        [OperationContract]
        List<Review> ReadReviewForUser(int userId);

        [OperationContract]
        Review UpdateReview(Review model);

        [OperationContract]
        bool DeleteReview(Review model);
    }
}
