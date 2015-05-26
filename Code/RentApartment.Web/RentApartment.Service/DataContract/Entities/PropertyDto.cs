﻿using RentApartment.Core.Model.EF;
using RentApartment.Service.DataContract.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RentApartment.Service.DataContract.Entities
{
	[DataContract]
	public class PropertyDto
	{
		[DataMember]
		public int PropertyId { get; set; }

        [DataMember]
        public int FK_Account { get; set; }

        [DataMember]
        public int FK__Country { get; set; }

		[DataMember]
        public AccountDto Account { get; set; }

		[DataMember]
		public byte State { get; set; }

		[DataMember]
		public Nullable<long> PricePerNight { get; set; }

		[DataMember]
		public Nullable<long> PricePerMonth { get; set; }

		[DataMember]
		public Nullable<long> PricePerWeek { get; set; }

		[DataMember]
		public string Photos { get; set; }

		[DataMember]
		public string GreatTitle { get; set; }
		[DataMember]
		public string GreatSummary { get; set; }
		[DataMember]
		public byte BedRoom { get; set; }
		[DataMember]
		public int Bathroom { get; set; }
		[DataMember]
		public byte HomeType { get; set; }
		[DataMember]
		public string HomeTypeName { get; set; }

		[DataMember]
		public byte RoomType { get; set; }
		[DataMember]
		public string RoomTypeName { get; set; }

		[DataMember]
		public byte Accommodates { get; set; }
		[DataMember]
		public string Address1 { get; set; }
		[DataMember]
		public string Address2 { get; set; }
		[DataMember]
		public string City { get; set; }
		[DataMember]
		public string State2 { get; set; }
		[DataMember]
		public string Zip { get; set; }
		[DataMember]
		public int Country { get; set; }
        [DataMember]
        public List<AmenityDto> C_Amenities { get; set; }
	}
}