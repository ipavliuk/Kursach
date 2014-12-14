using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RentApartment.Service.DataContract.Response
{
	[DataContract]
	public class GetAccountProfileResponce : BaseResponse
	{
		[DataMember]
		public AccountProfile AccountProfile { get; set; }

	}
}