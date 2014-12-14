using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RentApartment.Service.DataContract.Entities
{
	[DataContract]
	public class Currency
	{
		[DataMember]
		public int Id { get; set; }
		[DataMember]
		public string Country { get; set; }
		[DataMember]
		public string Name { get; set; }
		[DataMember]
		public string Code { get; set; }
		[DataMember]
		public string Symbol { get; set; }

	}
}