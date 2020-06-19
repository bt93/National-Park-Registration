using Capstone.DAL;
using Capstone.Models;
using CLI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Views
{
    
    
        /// <summary>
        /// A sub-menu 
        /// </summary>
        public class CampgroundMenu : CLIMenu
        {
            // Store any private variables here....
            private ParkSqlDAO parkDao;
            private CampgroundSqlDAO campgroundDao;
            private SiteSqlDAO siteDao;
            private ReservationSqlDAO reservationDao;
            private Park park;

            /// <summary>
            /// Constructor adds items to the top-level menu
            /// </summary>
            public CampgroundMenu(Park park, CampgroundSqlDAO campgroundDao, SiteSqlDAO siteDao, ReservationSqlDAO reservationDao) :
                base("Park Menu")
            {
                this.parkDao = parkDao;
                this.campgroundDao = campgroundDao;
                this.siteDao = siteDao;
                this.reservationDao = reservationDao;
                this.park = park;
            }

            protected override void SetMenuOptions()
            {
                this.menuOptions.Add("1", "View Campgrounds");
                this.menuOptions.Add("2", "Search for Reservation");
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
                        WriteError("Not yet implemented");
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
                Console.WriteLine("Display some data here, AFTER the sub-menu is shown....");
                ResetColor();
            }

        //Console.WriteLine($"Location: {this.park.Location}");
        private void PrintHeader()
            {
                SetColor(ConsoleColor.Blue);
                Console.WriteLine(Figgle.FiggleFonts.Standard.Render(this.park.Name));
                Console.WriteLine($"Name: ");
                Console.Write("Open");
                ResetColor();
            }

        }
    }


