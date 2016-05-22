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
    public class StoresController : ODataController
    {
        private StoreRepository _repo = new StoreRepository();

        // GET api/Stores
        [EnableQuery]
        public IQueryable<Store> GetStores()
        {
            return _repo.Read();
        }

        // GET api/Stores/5
        [EnableQuery]
        public SingleResult<Store> GetStores([FromODataUri] int key)
        {
            IQueryable<Store> store = _repo.Read(key);

            return SingleResult.Create(store);
        }

        // PUT api/Stores/5
        public IHttpActionResult PutStores([FromODataUri] int id, Store Store)
        {
            if (id != Store.Id)
            {
                return BadRequest();
            }
            
            try
            {
                _repo.Update(Store);
            }
            catch (Exception)
            {
                if (!StoreExists(id))
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

        // POST api/Stores
        [ResponseType(typeof(Store))]
        public IHttpActionResult PostStores(Store Store)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.Create(Store);

            return CreatedAtRoute("DefaultApi", new { id = Store.Id }, Store);
        }

        // DELETE api/Stores/5
        [ResponseType(typeof(Store))]
        public IHttpActionResult DeleteStores(int id)
        {
            Store Store = _repo.Read(id).FirstOrDefault();
            if (Store == null)
            {
                return NotFound();
            }

            _repo.Delete(id);

            return Ok(Store);
        }

        private bool StoreExists(int id)
        {
            return _repo.Read(id) != null;
        }
    }
}
