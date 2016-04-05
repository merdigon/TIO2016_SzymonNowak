using LiteDBService.BookRepository;
using ModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace RestWebApi.Controllers
{
    public class BooksController : ApiController
    {
        BookRepository bookRepo = new BookRepository();

        // GET api/books
        public HttpResponseMessage Get()
        {
            try
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, bookRepo.ReadAll());
            }
            catch(Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        // GET api/books?search=
        public HttpResponseMessage Get([FromUri] string search)
        {
            try
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, bookRepo.ReadAll().Where(x => x.BookTitle.Contains(search)));
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        // GET api/books/5
        public HttpResponseMessage Get(int id)
        {
            try
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, bookRepo.Read(id));
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        // POST api/books
        public HttpResponseMessage Post([FromBody]Book value)
        {
            try
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, bookRepo.Create(value));
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        // PUT api/books/5
        public HttpResponseMessage Put(int id, [FromBody]Book value)
        {
            try
            {
                value.Id = id;
                return this.Request.CreateResponse(HttpStatusCode.OK, bookRepo.Update(value));
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        // DELETE api/books/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, bookRepo.Delete(new Book() { Id = id }));
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
    }
}
