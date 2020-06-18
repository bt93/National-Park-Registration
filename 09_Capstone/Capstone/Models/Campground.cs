using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Capstone.Models
{
    public class Campground
    {
        public int CampgroundId { get; set; }
        public string Name { get; set; }
        public int OpenMonth { get; set; }
        public int CloseMonth { get; set; }
        public decimal DailyFee { get; set; }
        public List<Site> Sites { get; set; }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
