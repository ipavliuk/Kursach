using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AutoMapper;
using RentApartment.Core.Common;
using RentApartment.Core.Infrastructure;
using RentApartment.Core.Model.EF;
using RentApartment.Service.DataContract.Entities;
using RentApartment.Service.DataContract.Request;
using RentApartment.Service.DataContract.Response;

namespace RentApartment.Service
{
	public class RApmentAdministration : IRApmentAdministration
	{
		public RApmentAdministration()
		{
			Mapper.CreateMap<PropertyListing, PropertyDto>();
			Mapper.CreateMap<Reservations, ReservationDto>();
            Mapper.CreateMap<Account, AccountDto>();
		}

		public GetPropertyListingResponse GetPropertyListing(GetPropertyListingRequest request)
		{
			var response = new GetPropertyListingResponse();

			
			if (request == null)
			{
				response.ErrorId = (int)RApmentErrors.FailedProceedRequest;
				return response;
			}
			
			try
			{
				response.ErrorId = (int)RApmentErrors.Ok;

                List<PropertyListing> propertyListings = 
                    RentApartmentManager.Instance.LoadPropertyListingByFilter(request.City, request.OwnerId, 
                                                    request.PropertyId, request.HomeType, request.RoomNumbers).ToList();

			
				response.PropertListing = Mapper.Map<List<PropertyListing>, List<PropertyDto>>(propertyListings.ToList());

			}
			catch (Exception ex)
			{
				response.ErrorId = (int)RApmentErrors.OperationError;
				response.ErrorDesc = ex.Message;
				//Logger.Instance.Error("AuthenticateChatHost - ", ex);
			}

			return response;
		}

		public GetReservationsResponse GetReservations(GetReservationsRequest request)
		{
			var response = new GetReservationsResponse();


			if (request == null)
			{
				response.ErrorId = (int)RApmentErrors.FailedProceedRequest;
				return response;
			}

			try
			{
				response.ErrorId = (int)RApmentErrors.Ok;
				IEnumerable<Reservations> reservations = 
					RentApartmentManager.Instance.GetReservations(request.AccountId, request.ReservationStart, 
															request.ReservationEnd, request.ReservationStatus);

				//foreach (var item in reservations)
				//{
				//	ReservationDto reservation = TranslateReservationEntityToReservation(item);
				//	response.Reservation.Add(reservation);
				//}
				response.Reservation = Mapper.Map<List<Reservations>, List<ReservationDto>>(reservations.ToList());

			}
			catch (Exception ex)
			{
				response.ErrorId = (int)RApmentErrors.OperationError;
				response.ErrorDesc = ex.Message;
				//Logger.Instance.Error("AuthenticateChatHost - ", ex);
			}
			

			return response;
		}


        public GetAccountsResponse GetAccounts(GetAccountsRequest request)
        {
            var response = new GetAccountsResponse();


            if (request == null)
            {
                response.ErrorId = (int)RApmentErrors.FailedProceedRequest;
                return response;
            }

            try
            {
                response.ErrorId = (int)RApmentErrors.Ok;
                IEnumerable<Account> accounts =
                    RentApartmentManager.Instance.GetAccounts(request.AccountId, request.Name, request.City);

                
                response.Accounts = Mapper.Map<List<Account>, List<AccountDto>>(accounts.ToList());

            }
            catch (Exception ex)
            {
                response.ErrorId = (int)RApmentErrors.OperationError;
                response.ErrorDesc = ex.Message;
                //Logger.Instance.Error("AuthenticateChatHost - ", ex);
            }


            return response;
        }
		//private ReservationDto TranslateReservationEntityToReservation(Reservations reservationEF)
		//{

		//	if (reservationEF == null)
		//		return new ReservationDto();

		//	ReservationDto acc = new ReservationDto()
		//	{
		//		AccountId = reservationEF.FK_Account,
		//		ReservationId = reservationEF.ReservationId,
		//		PropertyListingId = reservationEF.FK_PropertyListing,
		//		Currency = reservationEF.C_Currency.Id,
		//		ReservationStart = reservationEF.ReservationStart,
		//		ReservationEnd = reservationEF.ReservationEnd,
		//		ReservationNote = reservationEF.ReservationNote,
		//		ReservationStatus = reservationEF.ReservationStatus,
		//		PropertyItem = TranslatePropertyListingEntityToProperty(reservationEF.PropertyListing)
		//	};

		//	return acc;
		//}

		//private PropertyDto TranslatePropertyListingEntityToProperty(PropertyListing propertyEF)
		//{

		//	if (propertyEF == null)
		//		return new PropertyDto();

		//	PropertyDto acc = new PropertyDto()
		//	{
		//		PropertyId = propertyEF.PropertyId,
		//		AccountId = propertyEF.FK_Account,
		//		Accommodates = propertyEF.Accommodates,
		//		Country = propertyEF.FK__Country,
		//		City = propertyEF.City,
		//		Address1 = propertyEF.Address1,
		//		Address2 = propertyEF.Address2,
		//		State = propertyEF.State,
		//		State2 = propertyEF.State2,
		//		Zip = propertyEF.Zip,
		//		Bathroom = propertyEF.Bathroom,
		//		BedRoom = propertyEF.BedRoom,
		//		GreatSummary = propertyEF.GreatSummary,
		//		GreatTitle = propertyEF.GreatTitle,
		//		HomeType = propertyEF.HomeType,
		//		Photos = propertyEF.Photos,
		//		PricePerMonth = propertyEF.PricePerMonth,
		//		PricePerNight = propertyEF.PricePerNight,
		//		PricePerWeek = propertyEF.PricePerWeek,
		//		RoomType = propertyEF.RoomType
		//	};

		//	return acc;
		//}

	}
}
