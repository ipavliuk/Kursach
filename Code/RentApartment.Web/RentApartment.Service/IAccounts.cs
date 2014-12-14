using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RentApartment.Service.DataContract.Request;
using RentApartment.Service.DataContract.Response;

namespace RentApartment.Service
{
	[ServiceContract]
	public interface IAccounts
	{
		[OperationContract]
		AuthenticationResponse Authenticate(AuthenticationRequest request);

		[OperationContract]
		GetAccountProfileResponce GetAccountPropfile(GetAccountProfileRequest request);

	}
}
