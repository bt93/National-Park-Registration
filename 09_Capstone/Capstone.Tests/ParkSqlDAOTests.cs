using Capstone.DAL;
using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Transactions;

namespace Capstone.Tests
{
    [TestClass]
    public class ParkSqlDAOTests
    {
        private string connectionString = @"Server=.\SQLEXPRESS; Database=npcampground; Trusted_Connection=True;";
        private TransactionScope transaction;

        // Hold ids
        

        [TestInitialize]
        public void SetupDB()
        {
            transaction = new TransactionScope();

            string sqlScript = File.ReadAllText("Setup.sql");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlScript, conn);
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    
                }
            }
        }

        [TestCleanup]
        public void CleanUp()
        {
            // Roll back
            transaction.Dispose();
        }

        [TestMethod]
        public void CountOfParks()
        {
            // Arrange
            ParkSqlDAO dao = new ParkSqlDAO(connectionString);

            // Act
            IList<Park> list = dao.GetParks();

            // Assert
            Assert.AreEqual(3, list.Count);
        }
    }
}
