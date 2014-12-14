using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RentApartment.Service.DataContract.Response
{
	[DataContract]
	public class BaseResponse
	{
		[DataMember]
		public int ErrorId { get; set; }
		[DataMember]
		public string ErrorDesc { get; set; }
	}
}