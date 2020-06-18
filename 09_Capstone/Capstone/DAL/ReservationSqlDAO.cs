using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Capstone.DAL
{
   public class ReservationSqlDAO
    {
        private string connectionString;

        public ReservationSqlDAO(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }

        public int AddReservation(Reservation reservation)
        {
            using (SqlConnection conn = new SqlConnection()) 
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO Reservation (site_id, name, from_date, to_date, create_date) VALUES (@siteId, @name, @fromDate, @toDate, @createDate); Select @@identity;", conn );
                cmd.Parameters.AddWithValue("@siteId", reservation.SiteId);
                cmd.Parameters.AddWithValue("@name", reservation.Name);
                cmd.Parameters.AddWithValue("@fromDate", reservation.StartDate);
                cmd.Parameters.AddWithValue("@toDate", reservation.EndDate);
                cmd.Parameters.AddWithValue("@createDate", reservation.CreateDate);

                int id = Convert.ToInt32(cmd.ExecuteScalar());

                return id;
            }
            
        }
    }
   
}
