using ModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFPersonReviewRepositoryService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
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
        Person UpdatePerson(Person model);

        [OperationContract]
        bool DeletePerson(Person model);

        [OperationContract]
        int CreateReview(Review model);

        [OperationContract]
        Review ReadReview(int id);

        [OperationContract]
        List<Review> ReadReviews(int[] ids);

        [OperationContract]
        Review UpdateReview(Review model);

        [OperationContract]
        bool DeleteReview(Review model);
    }
}
