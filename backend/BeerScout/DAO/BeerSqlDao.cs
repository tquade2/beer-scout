using Capstone.DAO.Interfaces;
using Capstone.Exceptions;
using Capstone.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace Capstone.DAO
{
    public class BeerSqlDao : IBeerDao
    {
        private readonly string connectionString;

        public BeerSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public Beer CreateBeer(Beer beer)
        {
            Beer newBeer = null;

            string sql = @"INSERT INTO beers (name, description, abv, type, brewery_id)
                         OUTPUT INSERTED.beer_id
                         VALUES (@name, @description, @abv, @type, @brewery_id)";

            int newBeerId = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@name", beer.Name);
                    cmd.Parameters.AddWithValue("@description", beer.Description);
                    cmd.Parameters.AddWithValue("@abv", beer.ABV);
                    cmd.Parameters.AddWithValue("@type", beer.Type);
                    cmd.Parameters.AddWithValue("@brewery_id", beer.BreweryId);

                    newBeerId = Convert.ToInt32(cmd.ExecuteScalar());

                }
                newBeer = GetBeerById(newBeerId);
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return newBeer;
        }
        public IList<Beer> GetBeersByBreweryId(int id)
        {
            IList<Beer> beers = new List<Beer>();

            string sql = "SELECT * FROM beers WHERE brewery_id = @brewery_id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@brewery_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Beer beer = MapRowToBeer(reader);
                        beers.Add(beer);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return beers;
        }
        public IList<Beer> GetBeers()
        {
            IList<Beer> beers = new List<Beer>();
            string sql = "SELECT * FROM beers";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Beer beer = MapRowToBeer(reader);
                        beers.Add(beer);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }
            return beers;
        }
        public IList<Beer> GetBeersByUser(string username)
        {
            IList<Beer> beers = new List<Beer>();
            string sql = "SELECT * FROM beers JOIN breweries ON breweries.brewery_id = beers.brewery_id " +
                "JOIN user_brewery ON user_brewery.brewery_id = breweries.brewery_id " +
                "JOIN users ON users.user_id = user_brewery.user_id " +
                "WHERE users.username = @username";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Beer beer = MapRowToBeer(reader);
                        beers.Add(beer);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }
            return beers;
        }
        public Beer UpdateBeer(Beer updatedBeer)
        {
            string sql = "UPDATE beers SET name= @name, description= @description, type= @type, abv= @abv " +
            "WHERE beer_id = @id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", updatedBeer.Name);
                    cmd.Parameters.AddWithValue("@description", updatedBeer.Description);
                    cmd.Parameters.AddWithValue("@type", updatedBeer.Type);
                    cmd.Parameters.AddWithValue("@abv", updatedBeer.ABV);
                    cmd.Parameters.AddWithValue("@id", updatedBeer.Id);

                    int count = cmd.ExecuteNonQuery();
                    if (count == 1)
                    {
                        return updatedBeer;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
        public Beer GetBeerById(int id)
        {
            Beer beer = null;

            string sql = "SELECT * FROM beers WHERE beer_id = @beer_id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@beer_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        beer = MapRowToBeer(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return beer;
        }
        public bool DeleteBeerById(int id)
        {

            string sql = "DELETE FROM beers WHERE beer_id = @beer_id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@beer_id", id);

                    int count = cmd.ExecuteNonQuery();

                    if (count == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }
        }
        private Beer MapRowToBeer(SqlDataReader reader)
        {
            Beer beer = new Beer();
            beer.Id = Convert.ToInt32(reader["beer_id"]);
            beer.Description = Convert.ToString(reader["description"]);
            beer.Name = Convert.ToString(reader["name"]);
            beer.Type = Convert.ToString(reader["type"]);
            beer.ABV = Convert.ToString(reader["abv"]);
            beer.BreweryId = Convert.ToInt32(reader["brewery_id"]);
            return beer;
        }
    }
}
