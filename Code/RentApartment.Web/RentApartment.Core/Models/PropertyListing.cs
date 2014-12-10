using System;
using System.Collections.Generic;

namespace RentApartment.Core.Models
{
    public partial class PropertyListing
    {
        public PropertyListing()
        {
            this.GuestReviews = new List<GuestReview>();
            this.Reservations = new List<Reservation>();
            this.C_Amenities = new List<C_Amenities>();
        }

        public int PropertyId { get; set; }
        public int FK_Account { get; set; }
        public byte State { get; set; }
        public Nullable<long> PricePerNight { get; set; }
        public Nullable<long> PricePerMonth { get; set; }
        public Nullable<long> PricePerWeek { get; set; }
        public string Photos { get; set; }
        public string GreatTitle { get; set; }
        public string GreatSummary { get; set; }
        public byte BedRoom { get; set; }
        public int Bathroom { get; set; }
        public byte HomeType { get; set; }
        public byte RoomType { get; set; }
        public byte Accommodates { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State2 { get; set; }
        public string Zip { get; set; }
        public int FK__Country { get; set; }
        public virtual C_Country C_Country { get; set; }
        public virtual Account Account { get; set; }
        public virtual ICollection<GuestReview> GuestReviews { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<C_Amenities> C_Amenities { get; set; }
    }
}
