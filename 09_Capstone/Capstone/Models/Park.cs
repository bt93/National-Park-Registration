using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Park
    {
        public int ParkId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime EstablishedDate { get; set; }
        public int Area { get; set; }
        public int Visitor { get; set; }
        public string Description { get; set; }
        public List<Campground> Campgrounds { get; set; }

        public override string ToString()
        {
            return $"{this.Name} {this.Location} {this.Description}";
        }
    }
}
