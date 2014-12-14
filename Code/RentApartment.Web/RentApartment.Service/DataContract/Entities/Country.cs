using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RentApartment.Service.DataContract.Entities
{
	[DataContract]
	public class Country
	{
		[DataMember]
		public int Id { get; set; }
		[DataMember]
		public string IsoCode { get; set; }
		[DataMember]
		public string Name { get; set; }
	}
}