using Capstone.DAL;
using Capstone.Models;
using CLI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Views
{
    class SiteMenu : CLIMenu
    {
        // Store any private variables here....
        private ParkSqlDAO parkDao;
        private CampgroundSqlDAO campgroundDao;
        private SiteSqlDAO siteDao;
        private ReservationSqlDAO reservationDao;
        private Campground campground;
        private string arrivalDate;
        private string departureDate;
        

        /// <summary>
        /// Constructor adds items to the top-level menu
        /// </summary>
        public SiteMenu(Campground campground, SiteSqlDAO siteDao, ReservationSqlDAO reservationDao, string arrivalDate, string departureDate) :
            base("Park Menu")
        {
            this.siteDao = siteDao;
            this.reservationDao = reservationDao;
            this.campground = campground;
            this.arrivalDate = arrivalDate;
            this.departureDate = departureDate;
        }

        protected override void SetMenuOptions()
        {
            this.menuOptions.Add("1", "Search for Avaiable Reservation");
            this.menuOptions.Add("B", "Return to Previous Screen");
            this.quitKey = "B";
        }

        /// <summary>
        /// The override of ExecuteSelection handles whatever selection was made by the user.
        /// This is where any business logic is executed.
        /// </summary>
        /// <param name="choice">"Key" of the user's menu selection</param>
        /// <returns></returns>
        protected override bool ExecuteSelection(string choice)
        {
            switch (choice)
            {
                case "1": // Do whatever option 1 is

                    Pause("");
                    return true;
                case "2": // Do whatever option 2 is
                    WriteError("When this option is complete, we will exit this submenu by returning false from the ExecuteSelection method.");
                    Pause("");
                    return false;
            }
            return true;
        }

        protected override void BeforeDisplayMenu()
        {
            PrintHeader();
        }

        protected override void AfterDisplayMenu()
        {
            base.AfterDisplayMenu();
            SetColor(ConsoleColor.Green);
            Console.WriteLine("Make your selection Below: ");
            ResetColor();
        }

        //Console.WriteLine($"Location: {this.park.Location}");
        private void PrintHeader()
        {
            SetColor(ConsoleColor.Blue);
            
            Console.WriteLine(Figgle.FiggleFonts.Standard.Render(this.campground.Name));
            ListAvailableSites();
            
            ResetColor();
        }

        private void ListAvailableSites()
        {
            try
            {
                foreach (Site site in campground.Sites)
                {
                    site.UserStartTime = Convert.ToDateTime(arrivalDate);
                    site.UserEndTime = Convert.ToDateTime(departureDate);
                    int daysOfStay = Convert.ToInt32((site.UserEndTime.Date - site.UserStartTime.Date).TotalDays);
                    site.Reservations = reservationDao.getAllReservations(site.SiteId);

                    if (!site.IsBooked)
                    {
                        Console.WriteLine($"{site.SiteNumber} {site.MaxOccupancy}, {site.IsAccessible}, {site.MaxRvLength}, {site.HasUtilites} " +
                            $"{campground.DailyFee *= daysOfStay:C}");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Incorect Date Format, Please retry.");
                Pause("");
            }
            
        }
    }
}
