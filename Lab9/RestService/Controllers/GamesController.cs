using CommonData.DataBaseProvider;
using CommonData.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.OData;

namespace RestService.Controllers
{
    public class GamesController : ODataController
    {
        private GameRepository _repo = new GameRepository();

        // GET api/Games
        [EnableQuery]
        public IQueryable<Game> Get()
        {            
            return _repo.Read();
        }

        // GET api/Games/5
        [EnableQuery]
        public SingleResult<Game> Get([FromODataUri] int key)
        {
            IQueryable<Game> game = _repo.Read(key);

            return SingleResult.Create(game);
        }

        // PUT api/Games/5
        public IHttpActionResult Put([FromODataUri] int id, Game Game)
        {
            if (id != Game.Id)
            {
                return BadRequest();
            }
            
            try
            {
                _repo.Update(Game);
            }
            catch (Exception)
            {
                if (!GameExists(id))
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

        // POST api/Games
        [ResponseType(typeof(Game))]
        public IHttpActionResult Post(Game Game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.Create(Game);

            return CreatedAtRoute("DefaultApi", new { id = Game.Id }, Game);
        }

        // DELETE api/Games/5
        [ResponseType(typeof(Game))]
        public IHttpActionResult Delete([FromODataUri] int id)
        {
            Game game = _repo.Read(id).FirstOrDefault();
            if (game == null)
            {
                return NotFound();
            }

            _repo.Delete(id);

            return Ok(game);
        }

        private bool GameExists(int id)
        {
            return _repo.Read(id) != null;
        }
    }
}
