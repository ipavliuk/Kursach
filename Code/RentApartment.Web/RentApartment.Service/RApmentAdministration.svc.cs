using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
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

		public GetPropertiesResponse GetProperties(GetPropertiesRequest request)
		{
			var response = new GetPropertiesResponse();

			
			if (request == null)
			{
				response.ErrorId = (int)RApmentErrors.FailedProceedRequest;
				return response;
			}
			
			try
			{
				response.ErrorId = (int)RApmentErrors.Ok;

				IEnumerable<PropertyListing> propertyListings = (request.AccountId != null) 
													? AdminManager.Instance.GetPropertyByAccount((int)request.AccountId)
													: AdminManager.Instance.GetPropertyByCityCountry(request.City, 
																								request.Country);

				foreach (var item in propertyListings)
				{
					Property property = TranslatePropertyListingEntityToProperty(item);
					response.Properties.Add(property);
				}
				
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
					AdminManager.Instance.GetReservations(request.AccountId, request.ReservationStart, 
															request.ReservationEnd, request.ReservationStatus);

				foreach (var item in reservations)
				{
					Reservation reservation = TranslateReservationEntityToReservation(item);
					response.Reservation.Add(reservation);
				}
			}
			catch (Exception ex)
			{
				response.ErrorId = (int)RApmentErrors.OperationError;
				response.ErrorDesc = ex.Message;
				//Logger.Instance.Error("AuthenticateChatHost - ", ex);
			}
			

			return response;
		}

		private Reservation TranslateReservationEntityToReservation(Reservations reservationEF)
		{

			if (reservationEF == null)
				return new Reservation();

			Reservation acc = new Reservation()
			{
				AccountId = reservationEF.FK_Account,
				ReservationId = reservationEF.ReservationId,
				PropertyListingId = reservationEF.FK_PropertyListing,
				Currency = reservationEF.C_Currency.Id,
				ReservationStart = reservationEF.ReservationStart,
				ReservationEnd = reservationEF.ReservationEnd,
				ReservationNote = reservationEF.ReservationNote,
				ReservationStatus = reservationEF.ReservationStatus,
				PropertyItem = TranslatePropertyListingEntityToProperty(reservationEF.PropertyListing)
			};

			return acc;
		}

		private Property TranslatePropertyListingEntityToProperty(PropertyListing propertyEF)
		{

			if (propertyEF == null)
				return new Property();

			Property acc = new Property()
			{
				PropertyId = propertyEF.PropertyId,
				AccountId = propertyEF.FK_Account,
				Accommodates = propertyEF.Accommodates,
				Country = propertyEF.FK__Country,
				City = propertyEF.City,
				Address1 = propertyEF.Address1,
				Address2 = propertyEF.Address2,
				State = propertyEF.State,
				State2 = propertyEF.State2,
				Zip = propertyEF.Zip,
				Bathroom = propertyEF.Bathroom,
				BedRoom = propertyEF.BedRoom,
				GreatSummary = propertyEF.GreatSummary,
				GreatTitle = propertyEF.GreatTitle,
				HomeType = propertyEF.HomeType,
				Photos = propertyEF.Photos,
				PricePerMonth = propertyEF.PricePerMonth,
				PricePerNight = propertyEF.PricePerNight,
				PricePerWeek = propertyEF.PricePerWeek,
				RoomType = propertyEF.RoomType
			};

			return acc;
		}

	}
}
