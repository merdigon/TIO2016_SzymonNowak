﻿using CommonData.DataBaseProvider;
using CommonData.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.OData;
using System.Web.OData.Routing;

namespace RestService.Controllers
{
    public class GamesController : ODataController
    {
        private GameRepository _gameRepo = new GameRepository();
        private CardShirtRepository _cardShirtRepo = new CardShirtRepository();

        [HttpGet]
        [ODataRoute("GetAvailableCardShirts()")]
        public IHttpActionResult GetAvailableCardShirts()
        {
            var shirts = _cardShirtRepo.Read();
            return Ok(shirts);
        }

        // GET api/Games
        [EnableQuery]
        public IQueryable<Game> Get()
        {            
            return _gameRepo.Read();
        }

        // GET api/Games/5
        [EnableQuery]
        public SingleResult<Game> Get([FromODataUri] int key)
        {
            IQueryable<Game> game = _gameRepo.Read(key);

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
                _gameRepo.Update(Game);
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

            _gameRepo.Create(Game);

            return CreatedAtRoute("DefaultApi", new { id = Game.Id }, Game);
        }

        // DELETE api/Games/5
        [ResponseType(typeof(Game))]
        public IHttpActionResult Delete([FromODataUri] int id)
        {
            Game game = _gameRepo.Read(id).FirstOrDefault();
            if (game == null)
            {
                return NotFound();
            }

            _gameRepo.Delete(id);

            return Ok(game);
        }

        private bool GameExists(int id)
        {
            return _gameRepo.Read(id) != null;
        }
    }
}