using System;
using System.Collections.Generic;

namespace RentApartment.Core.Models
{
    public partial class Reservation
    {
        public int ReservationId { get; set; }
        public int FK_Account { get; set; }
        public int FK_PropertyListing { get; set; }
        public int ReservationStatus { get; set; }
        public System.DateTime ReservationStart { get; set; }
        public System.DateTime ReservationEnd { get; set; }
        public string ReservationNote { get; set; }
        public int FK__Currency { get; set; }
        public virtual C_Currency C_Currency { get; set; }
        public virtual Account Account { get; set; }
        public virtual PropertyListing PropertyListing { get; set; }
    }
}
