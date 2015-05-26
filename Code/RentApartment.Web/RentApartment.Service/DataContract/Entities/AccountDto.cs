using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RentApartment.Service.DataContract.Response
{
	public class AccountDto
	{
		[DataMember]
		public int id { get; set; }

		[DataMember]
		public string AccountId { get; set; }

		[DataMember]
		public string FirstName { get; set; }

		[DataMember]
		public string LastName { get; set; }

		[DataMember]
		public string Email { get; set; }

		[DataMember]
		public bool IsEmailConfirmed { get; set; }

		[DataMember]
		public string Country { get; set; }

		[DataMember]
		public byte Roles { get; set; }

		[DataMember]
		public string RolesName { get; set; }

		[DataMember]
		public string City { get; set; }

		[DataMember]
		public string Address { get; set; }

		[DataMember]
		public string Mobile { get; set; }

		[DataMember]
		public Nullable<byte> Gender { get; set; }

		[DataMember]
		public string GenderName { get; set; }

		[DataMember]
		public string PostalCode { get; set; }

		[DataMember]
		public Nullable<int> Language { get; set; }

		[DataMember]
		public Nullable<DateTime> Birthday { get; set; }

		[DataMember]
		public bool IsValidated { get; set; }

		[DataMember]
		public string PictureUrl { get; set; }

		[DataMember]
		public string Login { get; set; }

		[DataMember]
		public string PasswordHash { get; set; }
	}
}