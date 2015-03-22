using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using RentApartment.Service.DataContract.Entities;

namespace RentApartment.Service.DataContract.Response
{
	[DataContract]
	public class CurrenciesResponse : BaseResponse
	{
		[DataMember]
		public List<CurrencyDto> Currensies { get; set; }
	}
}