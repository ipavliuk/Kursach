using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using RentApartment.Service.DataContract.Entities;

namespace RentApartment.Service.DataContract.Request
{
    [DataContract]
    public class ChangedPropertyRequest
    {
        [DataMember]
        public PropertyDto Property { get; set; }
    }
}