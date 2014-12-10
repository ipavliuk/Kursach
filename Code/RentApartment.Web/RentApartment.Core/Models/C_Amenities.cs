using System;
using System.Collections.Generic;

namespace RentApartment.Core.Models
{
    public partial class C_Amenities
    {
        public C_Amenities()
        {
            this.PropertyListings = new List<PropertyListing>();
        }

        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<PropertyListing> PropertyListings { get; set; }
    }
}
