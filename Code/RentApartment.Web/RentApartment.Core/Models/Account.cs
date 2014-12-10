using System;
using System.Collections.Generic;

namespace RentApartment.Core.Models
{
    public partial class Account
    {
        public Account()
        {
            this.GuestReviews = new List<GuestReview>();
            this.Messages = new List<Message>();
            this.PropertyListings = new List<PropertyListing>();
            this.Reservations = new List<Reservation>();
        }

        public int id { get; set; }
        public string AccountId { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public int FK__Country { get; set; }
        public byte FK__Roles { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public Nullable<byte> Gender { get; set; }
        public string PostalCode { get; set; }
        public Nullable<int> Language { get; set; }
        public bool IsValidated { get; set; }
        public string ImageSourceId { get; set; }
        public virtual C_Country C_Country { get; set; }
        public virtual C_Roles C_Roles { get; set; }
        public virtual ICollection<GuestReview> GuestReviews { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<PropertyListing> PropertyListings { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
