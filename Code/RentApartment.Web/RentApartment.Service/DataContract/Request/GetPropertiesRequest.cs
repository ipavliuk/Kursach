using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RentApartment.Service.DataContract.Request
{
    public class GetPropertyListingRequest : PaginationRequest
	{
		[DataMember]
		public int? OwnerId { get; set; }

		[DataMember]
		public string City { get; set; }

        [DataMember]
        public int? PropertyId { get; set; }

        [DataMember]
        public int? HomeType { get; set; }

        [DataMember]
        public int? RoomNumbers { get; set; }
	}
}