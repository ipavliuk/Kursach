using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using RentApartment.Service.DataContract.Entities;

namespace RentApartment.Service.DataContract.Response
{
	public class ReservationDto
	{
		[DataMember]
		public int ReservationId { get; set; }

		[DataMember]
		public int AccountId { get; set; }

		[DataMember]
		public int PropertyListingId { get; set; }

		[DataMember]
		public int ReservationStatus { get; set; }

		[DataMember]
		public System.DateTime ReservationStart { get; set; }

		[DataMember]
		public System.DateTime ReservationEnd { get; set; }

		[DataMember]
		public string ReservationNote { get; set; }

		[DataMember]
		public int Currency { get; set; }

		[DataMember]
		public PropertyDto PropertyListing { get; set; }

		[DataMember]
		public int StayingDays { get; set; }

		[DataMember]
		public decimal TotalPrice { get; set; }

		[DataMember]
		public string ReservationStatusName { get; set; }


	}
}