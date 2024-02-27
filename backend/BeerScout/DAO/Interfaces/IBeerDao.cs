using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO.Interfaces
{
    public interface IBeerDao
    {
        public Beer CreateBeer(Beer beer);
        public IList<Beer> GetBeersByBreweryId(int id);
        public Beer GetBeerById(int id);
        public IList<Beer> GetBeers();
        public IList<Beer> GetBeersByUser(string username);
        public Beer UpdateBeer(Beer updatedBeer);
       
        public bool DeleteBeerById(int id);

    }
}
