using ObjectLibrary.DTO;
using ObjectLibrary.Repositories;
using RestService.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace RestService.Controllers
{
    public class PaintingsController : ApiController
    {
        private IPaintingsRepository _repo;
        private Logger _logger;

        public PaintingsController(IPaintingsRepository repo)
        {
            _repo = repo;
            _logger = new Logger();
        }

        // GET api/Paintings
        public IList<Painting> GetPaintings()
        {
            _logger.LogInfo("GET for Paintings was called");
            return _repo.Read();
        }

        // GET api/Paintings/5
        [ResponseType(typeof(Painting))]
        public IHttpActionResult GetPaintings(int id)
        {
            _logger.LogInfo("GET for Paintings was called");
            Painting painting = _repo.Read(id);
            if (painting == null)
            {
                return NotFound();
            }

            return Ok(painting);
        }

        // PUT api/Paintings/5
        public IHttpActionResult PutPaintings(int id, Painting painting)
        {
            _logger.LogInfo("PUT for Paintings was called");
            if (id != painting.Id)
            {
                return BadRequest();
            }
            
            try
            {
                _repo.Update(painting);
            }
            catch (Exception)
            {
                if (!PaintingExists(id))
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

        // POST api/Paintings
        [ResponseType(typeof(Painting))]
        public IHttpActionResult PostPaintings(Painting painting)
        {
            _logger.LogInfo("POST for Paintings was called");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.Create(painting);

            return CreatedAtRoute("DefaultApi", new { id = painting.Id }, painting);
        }

        // DELETE api/Paintings/5
        [ResponseType(typeof(Painting))]
        public IHttpActionResult DeletePaintings(int id)
        {
            _logger.LogInfo("DELETE for Paintings was called");
            Painting painting = _repo.Read(id);
            if (painting == null)
            {
                return NotFound();
            }

            _repo.Delete(id);

            return Ok(painting);
        }

        private bool PaintingExists(int id)
        {
            return _repo.Read(id) != null;
        }
    }
}
