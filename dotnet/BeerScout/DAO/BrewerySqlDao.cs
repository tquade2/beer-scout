using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using Capstone.Exceptions;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;
using Capstone.DAO.Interfaces;

namespace Capstone.DAO
{
    public class BrewerySqlDao : IBreweryDao
    {
        private readonly string connectionString;
        public BrewerySqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public Brewery CreateBrewery(Brewery brewery)
        {
            Brewery newBrewery = null;

            string sql = @"INSERT INTO breweries (name, street_address, city, state, zip, phone, email, website, map_link, description, category, logo, photo)
                         OUTPUT INSERTED.brewery_id
                         VALUES (@name, @street_address, @city, @state, @zip, @phone, @email, @website, @map_link, @description, @category, @logo, @photo)";

            int newBreweryId = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@name", brewery.Name);
                    cmd.Parameters.AddWithValue("@street_address", brewery.StreetAddress);
                    cmd.Parameters.AddWithValue("@city", brewery.City);
                    cmd.Parameters.AddWithValue("@state", brewery.State);
                    cmd.Parameters.AddWithValue("@zip", brewery.Zip);
                    cmd.Parameters.AddWithValue("@phone", brewery.Phone);
                    cmd.Parameters.AddWithValue("@email", brewery.Email);
                    cmd.Parameters.AddWithValue("@website", brewery.Website);
                    cmd.Parameters.AddWithValue("@map_link", brewery.MapLink);
                    cmd.Parameters.AddWithValue("@description", brewery.Description);
                    cmd.Parameters.AddWithValue("@category", brewery.Category);
                    cmd.Parameters.AddWithValue("@logo", brewery.Logo);
                    cmd.Parameters.AddWithValue("@photo", brewery.Photo);

                    newBreweryId = Convert.ToInt32(cmd.ExecuteScalar());

                }
                newBrewery = GetBreweryById(newBreweryId);
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return newBrewery;
        }
        public IList<Brewery> GetBreweries()
        {
            IList<Brewery> breweries = new List<Brewery>();

            string sql = "SELECT * FROM breweries";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Brewery brewery = MapRowToBrewery(reader);
                        breweries.Add(brewery);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return breweries;
        }
        public IList<Brewery> GetBreweriesByUserId(string username)
        {
            IList<Brewery> breweries = new List<Brewery>();

            string sql = "SELECT * FROM breweries " +
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
                        Brewery brewery = MapRowToBrewery(reader);
                        breweries.Add(brewery);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return breweries;
        }
        public Brewery UpdateBrewery(Brewery updatedBrewery)
        {
            string sql = @"UPDATE breweries SET
                            name = @name,
                            street_address = @street_address,
                            city = @city,
                            state = @state,
                            zip = @zip,
                            phone = @phone,
                            email = @email,
                            website = @website,
                            description = @description,
                            category = @category,
                            map_link = @map_link,
                            photo = @photo,
                            logo = @logo
                            WHERE brewery_id = @brewery_id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", updatedBrewery.Name);
                    cmd.Parameters.AddWithValue("@street_address", updatedBrewery.StreetAddress);
                    cmd.Parameters.AddWithValue("@city", updatedBrewery.City);
                    cmd.Parameters.AddWithValue("@state", updatedBrewery.State);
                    cmd.Parameters.AddWithValue("@zip", updatedBrewery.Zip);
                    cmd.Parameters.AddWithValue("@phone", updatedBrewery.Phone);
                    cmd.Parameters.AddWithValue("@email", updatedBrewery.Email);
                    cmd.Parameters.AddWithValue("@website", updatedBrewery.Website);
                    cmd.Parameters.AddWithValue("@map_link", updatedBrewery.MapLink);
                    cmd.Parameters.AddWithValue("@description", updatedBrewery.Description);
                    cmd.Parameters.AddWithValue("@category", updatedBrewery.Category);
                    cmd.Parameters.AddWithValue("@photo", updatedBrewery.Photo);
                    cmd.Parameters.AddWithValue("@logo", updatedBrewery.Logo);
                    cmd.Parameters.AddWithValue("@brewery_id", updatedBrewery.Id);

                    int count = cmd.ExecuteNonQuery();
                    if (count == 1)
                    {
                        return updatedBrewery;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
        public Brewery GetBreweryById(int id)
        {
            Brewery brewery = null;

            string sql = "SELECT * FROM breweries WHERE brewery_id = @brewery_id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@brewery_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        brewery = MapRowToBrewery(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return brewery;
        }
        private Brewery MapRowToBrewery(SqlDataReader reader)
        {
            Brewery brewery = new Brewery();

            brewery.Id = Convert.ToInt32(reader["brewery_id"]);
            brewery.Name = Convert.ToString(reader["name"]);
            brewery.StreetAddress = Convert.ToString(reader["street_address"]);
            brewery.City = Convert.ToString(reader["city"]);
            brewery.State = Convert.ToString(reader["state"]);
            brewery.Zip = Convert.ToString(reader["zip"]);
            brewery.Phone = Convert.ToString(reader["phone"]);
            brewery.Email = Convert.ToString(reader["email"]);
            brewery.Website = Convert.ToString(reader["website"]);
            brewery.MapLink = Convert.ToString(reader["map_link"]);
            brewery.Description = Convert.ToString(reader["description"]);
            brewery.Category = Convert.ToString(reader["category"]);
            brewery.Photo = Convert.ToString(reader["photo"]);
            brewery.Logo = Convert.ToString(reader["logo"]);

            return brewery;
        }
    }
}
