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
    public class ReviewSqlDao : IReviewDao
    {
        private readonly string connectionString;
        public ReviewSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Review CreateReview(Review review)
        {
            Review newReview = null;

            string sql = @"INSERT INTO reviews (title, description, rating, beer_id)
                         OUTPUT INSERTED.review_id
                         VALUES (@title, @description, @rating, @beer_id)";

            int newReviewId = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@title", review.Title);
                    cmd.Parameters.AddWithValue("@description", review.Description);
                    cmd.Parameters.AddWithValue("@rating", review.Rating);
                    cmd.Parameters.AddWithValue("@beer_id", review.BeerId);


                    newReviewId = Convert.ToInt32(cmd.ExecuteScalar());

                }
                newReview = GetReviewById(newReviewId);
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return newReview;
        }

        public Review GetReviewById(int id)
        {
            Review review = null;

            string sql = "SELECT * FROM reviews WHERE review_id = @review_id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@review_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        review = MapRowToReview(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return review;
        }


        public IList<Review> GetReviewsByBeerId(int id)
        {
            IList<Review> reviews = new List<Review>();

            string sql = "SELECT * FROM reviews WHERE beer_id = @beer_id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@beer_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Review review = MapRowToReview(reader);
                        reviews.Add(review);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return reviews;
        }

        private Review MapRowToReview(SqlDataReader reader)
        {
            Review review = new Review();
            review.Id = Convert.ToInt32(reader["review_id"]);
            review.Title = Convert.ToString(reader["title"]);
            review.Rating = Convert.ToInt32(reader["rating"]);
            review.Description = Convert.ToString(reader["description"]);
            review.BeerId = Convert.ToInt32(reader["beer_id"]);
            return review;
        }
    }
}
