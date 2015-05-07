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
	public interface IRApmentAdministration
	{
		[OperationContract]
		AuthenticationResponse Authenticate(AuthenticationRequest request);

		[OperationContract]
		GetPropertyListingResponse GetPropertyListing(GetPropertyListingRequest request);

		[OperationContract]
		GetReservationsResponse GetReservations(GetReservationsRequest request);

        [OperationContract]
        GetAccountsResponse GetAccounts(GetAccountsRequest request);
        
        [OperationContract]
        BaseResponse CreateAccount(ChangeAccountRequest request);

        [OperationContract]
        BaseResponse UpdateAccount(ChangeAccountRequest request);

        [OperationContract]
        BaseResponse RemoveAccount(int accountId);

        [OperationContract]
        GetDictionaryDataResponse GetHomeType();

        [OperationContract]
        GetDictionaryDataResponse GetRoomType();

        [OperationContract]
        GetDictionaryDataResponse GetUserRole();

        [OperationContract]
        GetDictionaryDataResponse GetGender();

        [OperationContract]
        AmenitiesResponse GetAmenities();

        [OperationContract]
        GetApartmentReservationsResponse GetApartmentReservation(int propertyId);

        [OperationContract]
        BaseResponse MakeApartmentReservation(int accountId, int propertyId, DateTime startDate, DateTime endDate, string note);

        [OperationContract]
        BaseResponse CreateProperty(ChangedPropertyRequest request);
        [OperationContract]
        BaseResponse UpdateProperty(ChangedPropertyRequest request);
        [OperationContract]
        BaseResponse RemoveProperty(int propertyId);

		[OperationContract]
		GetPropertyListingResponse GetBookedPropertyByAccount(int accountId);

		[OperationContract]
		GetPropertyListingResponse GetPropertyByAccount(int accountId);
	}
}
