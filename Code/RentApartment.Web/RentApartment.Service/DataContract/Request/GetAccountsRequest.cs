using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace RentApartment.Service.DataContract.Request
{
    public class GetAccountsRequest : PaginationRequest
    {
         [DataMember]
        public int? AccountId { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}