using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace RentApartment.Service.DataContract.Response
{
    [DataContract]
    public class GetApartmentReservationsResponse :BaseResponse
    {
        [DataMember]
        public List<DateTime> BlackOutDates { get; set; } 
    }
}