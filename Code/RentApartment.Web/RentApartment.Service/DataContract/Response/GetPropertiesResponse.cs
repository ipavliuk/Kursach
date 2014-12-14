using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using RentApartment.Service.DataContract.Entities;

namespace RentApartment.Service.DataContract.Response
{
	[DataContract]
	public class GetPropertiesResponse : BaseResponse
	{
		[DataMember]
		public List<Property> Properties { get; set; }
	}
}