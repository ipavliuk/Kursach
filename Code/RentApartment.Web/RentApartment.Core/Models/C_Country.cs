using System;
using System.Collections.Generic;

namespace RentApartment.Core.Models
{
    public partial class C_Country
    {
        public C_Country()
        {
            this.Accounts = new List<Account>();
            this.PropertyListings = new List<PropertyListing>();
        }

        public int id { get; set; }
        public string IsoCode { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<PropertyListing> PropertyListings { get; set; }
    }
}
