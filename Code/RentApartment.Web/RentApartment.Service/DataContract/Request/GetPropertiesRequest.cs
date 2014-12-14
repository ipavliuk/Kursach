using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RentApartment.Service.DataContract.Request
{
	public class GetPropertiesRequest
	{
		[DataMember]
		public int? AccountId { get; set; }

		[DataMember]
		public string City { get; set; }

		[DataMember]
		public int Country { get; set; }
	}
}