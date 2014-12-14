using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RentApartment.Service.DataContract.Request
{
	[DataContract]

	public class AuthenticationRequest
	{
		[DataMember]
		public string Login { get; set; }

		[DataMember]
		public string Password { get; set; }
	}
}