using Capstone.DAL;
using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Transactions;

namespace Capstone.Tests
{
    [TestClass]
    public class ReservationTests
    {
        private string connectionString = @"Server=.\SQLEXPRESS; Database=npcampground; Trusted_Connection=True;";
        private TransactionScope transaction;

        // Hold ids
        private int siteOne;
        private int resOne;
        private int name;

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
                    siteOne = Convert.ToInt32(rdr["Site1"]);
                    resOne = Convert.ToInt32(rdr["Res1"]);
                    name = Convert.ToInt32(rdr["Blackwoods"]);
                }
            }
        }

        [TestCleanup]
        public void CleanUp()
        {
            // Roll back
            transaction.Dispose();
        }

        // TODO: Make DAOs to test with
        [TestMethod]
        public void CheckIfSiteIsReserved()
        {
            // Arrange
            ReservationSqlDAO dao = new ReservationSqlDAO(connectionString);
            SiteSqlDAO dao1 = new SiteSqlDAO(connectionString);

            // Act
            IList<Reservation> list = dao.getAllReservations(siteOne);
            IList<Site> sites = dao1.GetSiteId(name);

            // Assert
            Assert.AreEqual(false, sites[0].IsAvailable);

        }
    }
}
