using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentApartment.Core.Model
{
	public class Account
	{
		public Account()
			{
				//this.GuestReviews = new HashSet<GuestReviews>();
				//this.Messages = new HashSet<Messages>();
				//this.PropertyListing = new HashSet<PropertyListing>();
				//this.Reservations = new HashSet<Reservations>();
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

			//public virtual C_Country C_Country { get; set; }
			//public virtual C_Roles C_Roles { get; set; }
			//public virtual ICollection<GuestReviews> GuestReviews { get; set; }
			//public virtual ICollection<Messages> Messages { get; set; }
			//public virtual ICollection<PropertyListing> PropertyListing { get; set; }
			//public virtual ICollection<Reservations> Reservations { get; set; }	}
}
