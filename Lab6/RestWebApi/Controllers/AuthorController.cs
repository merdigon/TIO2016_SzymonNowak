using LiteDBService.AuthorRepository;
using ModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestWebApi.Controllers
{
    public class AuthorController : ApiController
    {
        AuthorRepository authorRepo = new AuthorRepository();

        // GET api/author
        public HttpResponseMessage Get()
        {
            try
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, authorRepo.ReadAll());
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        // GET api/author?name=
        public HttpResponseMessage Get([FromUri] string name)
        {
            try
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, authorRepo.ReadAll().Where(x => x.AuthorName.Contains(name)));
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        // GET api/author/5
        public HttpResponseMessage Get(int id)
        {
            try
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, authorRepo.Read(id));
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        // POST api/author
        public HttpResponseMessage Post([FromBody]Author value)
        {
            try
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, authorRepo.Create(value));
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        // PUT api/author/5
        public HttpResponseMessage Put(int id, [FromBody]Author value)
        {
            try
            {
                value.Id = id;
                return this.Request.CreateResponse(HttpStatusCode.OK, authorRepo.Update(value));
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        // DELETE api/author/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, authorRepo.Delete(new Author() { Id = id }));
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
    }
}
