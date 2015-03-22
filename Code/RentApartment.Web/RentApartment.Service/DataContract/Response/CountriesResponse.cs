using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using RentApartment.Service.DataContract.Entities;
using RentApartment.Service.DataContract.Response;

namespace RentApartment.Service.DataContract.Response
{
	[DataContract]
	public class CountriesResponse : BaseResponse
	{
		[DataMember]
		public List<CountryDto> Countries { get; set; }
	}
}
