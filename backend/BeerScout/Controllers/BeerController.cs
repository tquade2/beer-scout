using Capstone.DAO.Interfaces;
using Capstone.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        public IBeerDao beerDao;

        public BeerController(IBeerDao beerDao)
        {
            this.beerDao = beerDao;
        }

        [HttpGet()]
        public ActionResult<List<Beer>> GetBeers()
        {
            return Ok(beerDao.GetBeers());
        }

        [HttpGet("byBrewery/{id}")]
        public ActionResult<List<Beer>> GetBeersByBreweryId(int id)
        {
            return Ok(beerDao.GetBeersByBreweryId(id));
        }

        [HttpGet("byUser/{username}")]
        public ActionResult<List<Beer>> GetBeersByUser(string username)
        {
            return Ok(beerDao.GetBeersByUser(username));
        }

        [HttpGet("{id}")]
        public ActionResult<Beer> GetBeerById(int id)
        {
            return Ok(beerDao.GetBeerById(id));
        }
   
        [HttpPost("createBeer")]
        public ActionResult<Beer> CreateBeer(Beer newBeer)
        {
            Beer result = beerDao.CreateBeer(newBeer);

            if (result.Id == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Beer> ChangeBeer(Beer updatedBeer)
        {
            Beer newBeer = beerDao.UpdateBeer(updatedBeer);

            if (newBeer == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(newBeer);
            }

        }

        [HttpDelete("{id}")]
        public ActionResult<Beer> Delete(int id)
        {
            bool result = beerDao.DeleteBeerById(id);
            if (result == true)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
    

