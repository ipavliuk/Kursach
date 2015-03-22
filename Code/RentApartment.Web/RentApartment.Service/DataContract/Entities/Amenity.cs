using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RentApartment.Service.DataContract.Entities
{
	[DataContract]
	public class AmenityDto
	{
		[DataMember]
		public int id { get; set; }
		[DataMember]
		public string Name { get; set; }
		[DataMember]
		public string Description { get; set; }
		[DataMember]
		public bool IsActive { get; set; }

	}
}