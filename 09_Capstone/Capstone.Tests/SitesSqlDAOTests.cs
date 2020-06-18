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
    public class SitesSqlDAOTests
    {
        private string connectionString = @"Server=.\SQLEXPRESS; Database=npcampground; Trusted_Connection=True;";
        private TransactionScope transaction;

        // Hold ids
        private int site1;

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
                    site1 = Convert.ToInt32(rdr["site1"]);
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
        public void CheckSiteId()
        {
            // Assign
            SiteSqlDAO dao = new SiteSqlDAO(connectionString);

            // Act
            IList<Site> list = dao.GetSiteId(site1);

            // Assert
            Assert.AreEqual(site1, list[0].SiteId);
        }
        //[TestMethod]
        //public void CheckCampgroundMonths()
        //{
        //    // Assign
        //    CampgroundSqlDAO dao = new CampgroundSqlDAO(connectionString);

        //    // Act
        //    IList<Campground> list = dao.GetCampgroundById(site1);

        //    // Assert
        //    Assert.AreEqual("Januar, list[0].OpenMonth);
        //}
    }
}
    

