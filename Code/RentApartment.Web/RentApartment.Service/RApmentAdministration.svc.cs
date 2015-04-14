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
using RentApartment.Core.DAL.Enums;

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


        public GetDictionaryDataResponse GetHomeType()
        {
            var response = new GetDictionaryDataResponse();
            try
            {
                response.Data = GetDictionary<HomeType>();
            }
            catch (Exception ex)
            {
                response.ErrorId = (int)RApmentErrors.OperationError;
                response.ErrorDesc = ex.Message;
            }

            return response;
        }

        public GetDictionaryDataResponse GetRoomType()
        {
            var response = new GetDictionaryDataResponse();
            try
            {
                response.Data = GetDictionary<RoomType>();
                
            }
            catch (Exception ex)
            {
                response.ErrorId = (int)RApmentErrors.OperationError;
                response.ErrorDesc = ex.Message;
            }

            return response;
        }

        public GetDictionaryDataResponse GetUserRole()
        {
            var response = new GetDictionaryDataResponse();
            try
            {
                response.Data = GetDictionary<UserRole>();
            }
            catch (Exception ex)
            {
                response.ErrorId = (int)RApmentErrors.OperationError;
                response.ErrorDesc = ex.Message;
            }

            return response;
        }
        private Dictionary<int, string> GetDictionary<T>() 
        {
           return  Enum.GetValues(typeof(T))
                       .Cast<T>()
                       .ToDictionary(t => Convert.ToInt32(t), t => t.ToString());
        }
	}
}
