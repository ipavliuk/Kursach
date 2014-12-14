using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using RentApartment.Core.Model.EF;

namespace RentApartment.Service.DataContract.Response
{
	[DataContract]
	public class AuthenticationResponse : BaseResponse
	{
		[DataMember]
		public bool AuthenticationResult { get; set; }

		[DataMember]
		public AccountProfile AccountProfile { get; set; }

	}
}