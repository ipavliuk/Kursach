using RentApartment.Service.DataContract.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RentApartment.Service.DataContract.Request
{
    [DataContract]
    public class ChangeAccountRequest
    {
        [DataMember]
        public AccountDto Account { get; set; }
    }
}