using Lab7.DBProvider;
using Lab7.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;

namespace Lab7.Controllers
{
    public class BookController : ApiController
    {
        private StoreContext db = new StoreContext();

        // GET api/Book
        public IQueryable<Book> GetBook()
        {
            return db.Books;
        }

        // GET api/Book/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult GetBook(int id)
        {
            Book Book = db.Books.Find(id);
            if (Book == null)
            {
                return NotFound();
            }

            return Ok(Book);
        }

        // PUT api/Book/5
        public IHttpActionResult PutBook(int id, Book Book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Book.Id)
            {
                return BadRequest();
            }

            db.Entry(Book).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Book
        [ResponseType(typeof(Book))]
        public IHttpActionResult PostBook(Book Book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Books.Add(Book);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = Book.Id }, Book);
        }

        // DELETE api/Book/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult DeleteBook(int id)
        {
            Book Book = db.Books.Find(id);
            if (Book == null)
            {
                return NotFound();
            }

            db.Books.Remove(Book);
            db.SaveChanges();

            return Ok(Book);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookExists(int id)
        {
            return db.Books.Count(e => e.Id == id) > 0;
        }
    }
}