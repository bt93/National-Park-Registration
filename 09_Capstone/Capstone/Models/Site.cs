using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Site
    {
        public int SiteId { get; set; }
        public bool IsAvailable
        {
            get
            {
                foreach (Reservation reservation in this.Reservations)
                {
                    if (reservation.StartDate > DateTime.Now && reservation.EndDate < DateTime.Now)
                    {
                        return false;
                    }
                }

                return true;
            }
        }
        public int SiteNumber { get; set; }
        public int MaxOccupancy { get; set; }
        public bool IsAccessible { get; set; }
        public int MaxRvLength { get; set; }
        public bool HasUtilites { get; set; }
        public List<Reservation> Reservations { get; set; }

        public override string ToString()
        {
            return $"{this.SiteNumber}";
        }
    }
}
