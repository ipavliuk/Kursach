using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RentApartment.Service.DataContract.Entities
{
	[DataContract]
	public class Role
	{
		[DataMember]
		public byte RoleId { get; set; }
		[DataMember]
		public string RoleName { get; set; }
		[DataMember]
		public string RoleDescription { get; set; }
	}
}