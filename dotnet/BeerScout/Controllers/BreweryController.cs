using Capstone.DAO.Interfaces;
using Capstone.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime;
using System.Security.Cryptography.X509Certificates;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BreweryController : ControllerBase
    {
        public IBreweryDao breweryDao;

        public BreweryController(IBreweryDao breweryDao)
        {
            this.breweryDao = breweryDao;
        }

        [HttpGet()]
        public ActionResult<List<Brewery>> GetBreweries()
        {
            return Ok(breweryDao.GetBreweries());
        }

        [HttpGet("byUser/{username}")]
        public ActionResult<List<Brewery>> GetBreweriesByUserId(string username)
        {
            return Ok(breweryDao.GetBreweriesByUserId(username));
        }

        [HttpGet("{id}")]
        public ActionResult<Brewery> GetBreweryById(int id)
        {
            return Ok(breweryDao.GetBreweryById(id));
        }

        [HttpPost("createBrewery")]
        public ActionResult<Brewery> CreateBrewery(Brewery newBrewery)
        {
            Brewery result = breweryDao.CreateBrewery(newBrewery);

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
        public ActionResult<Brewery> ChangeBrewery(Brewery updatedBrewery)
        {
           
            Brewery newBrewery = breweryDao.UpdateBrewery(updatedBrewery);

            if (newBrewery == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(newBrewery);
            }
        }
    }
}
