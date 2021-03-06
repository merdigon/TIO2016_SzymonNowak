﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using LiteDBService.PersonReviewRepository;
using ModelLibrary;

namespace WCFPersonReviewRepositoryService
{
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

        public List<Person> ReadPeople(int[] ids)
        {
            return PersonRepository.Read(ids);
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
