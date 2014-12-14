using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RentApartment.Service.DataContract.Request
{
	[DataContract]
	public class GetReservationsRequest
	{
		//[DataMember]
		public int? AccountId { get; set; }

		//[DataMember]
		//public int? PropertyListingId { get; set; }

		[DataMember]
		public int ReservationStatus { get; set; }

		[DataMember]
		public System.DateTime? ReservationStart { get; set; }

		[DataMember]
		public System.DateTime? ReservationEnd { get; set; }
	}
}