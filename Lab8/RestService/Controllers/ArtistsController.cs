using log4net.Core;
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
    public class ArtistsController : ApiController
    {
        private IArtistsRepository _repo;
        private Logger _logger;

        public ArtistsController(IArtistsRepository repo)
        {
            _repo = repo;
            _logger = new Logger();
        }

        // GET api/Artists
        public IList<Artist> GetArtists()
        {
            _logger.LogInfo("GET for Artist was called");
            return _repo.Read();
        }

        // GET api/Artists/5
        [ResponseType(typeof(Painting))]
        public IHttpActionResult GetArtists(int id)
        {
            _logger.LogInfo("GET for Artist was called");
            Artist artist = _repo.Read(id);
            if (artist == null)
            {
                return NotFound();
            }

            return Ok(artist);
        }

        // PUT api/Artists/5
        public IHttpActionResult PutArtists(int id, Artist artist)
        {
            _logger.LogInfo("PUT for Artist was called");
            if (id != artist.Id)
            {
                return BadRequest();
            }
            
            try
            {
                _repo.Update(artist);
            }
            catch (Exception)
            {
                if (!ArtistExists(id))
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

        // POST api/Artists
        [ResponseType(typeof(Artist))]
        public IHttpActionResult PostArtists(Artist artist)
        {
            _logger.LogInfo("POST for Artist was called");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.Create(artist);

            return CreatedAtRoute("DefaultApi", new { id = artist.Id }, artist);
        }

        // DELETE api/Artists/5
        [ResponseType(typeof(Artist))]
        public IHttpActionResult DeleteArtists(int id)
        {
            _logger.LogInfo("DELETE for Artist was called");
            Artist artist = _repo.Read(id);
            if (artist == null)
            {
                return NotFound();
            }

            _repo.Delete(id);

            return Ok(artist);
        }

        private bool ArtistExists(int id)
        {
            return _repo.Read(id) != null;
        }
    }
}
