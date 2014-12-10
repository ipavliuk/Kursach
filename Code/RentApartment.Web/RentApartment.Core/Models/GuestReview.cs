using System;
using System.Collections.Generic;

namespace RentApartment.Core.Models
{
    public partial class GuestReview
    {
        public int ReviewId { get; set; }
        public int FK_Account { get; set; }
        public int FK_PropertyListing { get; set; }
        public string Review { get; set; }
        public int RatingScore { get; set; }
        public virtual Account Account { get; set; }
        public virtual PropertyListing PropertyListing { get; set; }
    }
}
