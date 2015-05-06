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
            Mapper.CreateMap<C_Amenities, AmenityDto>();
            Mapper.CreateMap<PropertyDto, PropertyListing>();
            Mapper.CreateMap<AmenityDto, C_Amenities>();
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

			
				response.PropertListing = Mapper.Map<List<PropertyListing>, List<PropertyDto>>(propertyListings);

			}
			catch (Exception ex)
			{
				response.ErrorId = (int)RApmentErrors.OperationError;
				response.ErrorDesc = ex.Message;
				//Logger.Instance.Error("AuthenticateChatHost - ", ex);
			}

			return response;
		}

		public GetPropertyListingResponse GetBookedPropertyByAccount(int accountId)
		{
			var response = new GetPropertyListingResponse();


			if (accountId == 0)
			{
				response.ErrorId = (int)RApmentErrors.FailedProceedRequest;
				return response;
			}

			try
			{
				response.ErrorId = (int)RApmentErrors.Ok;

				List<PropertyListing> propertyListings =
					RentApartmentManager.Instance.GetBookedPropertyByAccount(accountId).ToList();


				response.PropertListing = Mapper.Map<List<PropertyListing>, List<PropertyDto>>(propertyListings);

			}
			catch (Exception ex)
			{
				response.ErrorId = (int)RApmentErrors.OperationError;
				response.ErrorDesc = ex.Message;
				//Logger.Instance.Error("AuthenticateChatHost - ", ex);
			}

			return response;
		}
		
		public GetPropertyListingResponse GetPropertyByAccount(int accountId)
		{
			var response = new GetPropertyListingResponse();


			if (accountId == 0)
			{
				response.ErrorId = (int)RApmentErrors.FailedProceedRequest;
				return response;
			}

			try
			{
				response.ErrorId = (int)RApmentErrors.Ok;

				List<PropertyListing> propertyListings =
					RentApartmentManager.Instance.GetPropertyByAccount(accountId).ToList();


				response.PropertListing = Mapper.Map<List<PropertyListing>, List<PropertyDto>>(propertyListings);

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
															request.ReservationEnd, request.ReservationStatus, request.City);

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

        public GetApartmentReservationsResponse GetApartmentReservation(int propertyId)
        {
            var response = new GetApartmentReservationsResponse();


            //if (request == null)
            //{
            //    response.ErrorId = (int)RApmentErrors.FailedProceedRequest;
            //    return response;
            //}

            try
            {
                response.ErrorId = (int)RApmentErrors.Ok;

                List<DateTime> blackouts =
                    RentApartmentManager.Instance.GetApartmentReservations(propertyId).ToList();


                response.BlackOutDates = blackouts;

            }
            catch (Exception ex)
            {
                response.ErrorId = (int)RApmentErrors.OperationError;
                response.ErrorDesc = ex.Message;
                //Logger.Instance.Error("AuthenticateChatHost - ", ex);
            }

            return response;
        }

        public BaseResponse MakeApartmentReservation(int accountId, int propertyId, DateTime startDate, DateTime endDate, string note)
        {
            var response = new BaseResponse();


            if (propertyId == 0)
            {
                response.ErrorId = (int)RApmentErrors.FailedProceedRequest;
                return response;
            }
            if (startDate > endDate)
            {
                response.ErrorId = (int)RApmentErrors.FailedProceedRequest;
                return response;
            }
            try
            {
                response.ErrorId = (int)RApmentErrors.Ok;

                bool result =
                    RentApartmentManager.Instance.MakeApartmentReservation(accountId, propertyId, startDate, endDate, note);


                

            }
            catch (Exception ex)
            {
                response.ErrorId = (int)RApmentErrors.OperationError;
                response.ErrorDesc = ex.Message;
                //Logger.Instance.Error("AuthenticateChatHost - ", ex);
            }

            return response;
        }


        public BaseResponse CreateProperty(ChangedPropertyRequest request)
        {
            var response = new BaseResponse();


            if (request.Property == null)
            {
                response.ErrorId = (int)RApmentErrors.FailedProceedRequest;
                return response;
            }
           
            try
            {
                response.ErrorId = (int)RApmentErrors.Ok;
                PropertyDto dto = request.Property;

                Account acc = RentApartmentManager.Instance.GetAccountById(dto.Account.id);

                PropertyListing property = new PropertyListing()
                {
                    
                    FK_Account = dto.Account.id,
                    State = dto.State,
                    PricePerNight = dto.PricePerNight,
                    PricePerMonth = dto.PricePerMonth,
                    PricePerWeek = dto.PricePerWeek,
                    Photos = dto.Photos,
                    GreatTitle = dto.GreatTitle,
                    GreatSummary = dto.GreatSummary,
                    BedRoom = dto.BedRoom,
                    Bathroom = dto.Bathroom,
                    HomeType = dto.HomeType,
                    RoomType = dto.RoomType,
                    Accommodates = dto.Accommodates,
                    Address1 = dto.Address1,
                    Address2 = dto.Address2,
                    City = dto.City,
                    State2 = dto.State2,
                    Zip = dto.Zip,
                    FK__Country = dto.Country,
                   // Currency = dto.Currency
                   //C_Amenities = Mapper.Map<List<AmenityDto>, List<C_Amenities>>(dto.C_Amenities)//,
                   //Account = acc
                };

	            var amenities = Mapper.Map<List<AmenityDto>, List<C_Amenities>>(dto.C_Amenities);

                bool result =
                    RentApartmentManager.Instance.CreateProperty(property, amenities );
                    //MakeApartmentReservation(accountId, propertyId, startDate, endDate, note)

            }
            catch (Exception ex)
            {
                response.ErrorId = (int)RApmentErrors.OperationError;
                response.ErrorDesc = ex.Message;
                //Logger.Instance.Error("AuthenticateChatHost - ", ex);
            }

            return response;
        }
        public BaseResponse UpdateProperty(ChangedPropertyRequest request)
        {
            var response = new BaseResponse();


            if (request.Property == null)
            {
                response.ErrorId = (int)RApmentErrors.FailedProceedRequest;
                return response;
            }

            try
            {
                response.ErrorId = (int)RApmentErrors.Ok;

                PropertyListing property = Mapper.Map<PropertyDto, PropertyListing>(request.Property);
                bool result =
                    RentApartmentManager.Instance.UpdateProperty(property);
                
            }
            catch (Exception ex)
            {
                response.ErrorId = (int)RApmentErrors.OperationError;
                response.ErrorDesc = ex.Message;
                //Logger.Instance.Error("AuthenticateChatHost - ", ex);
            }

            return response;
        }
        public BaseResponse RemoveProperty(int propertyId)
        {
            var response = new BaseResponse();
            try
            {
                response.ErrorId = (int)RApmentErrors.Ok;
                bool result =
                    RentApartmentManager.Instance.RemoveProperty(propertyId);
            }
            catch (Exception ex)
            {
                response.ErrorId = (int)RApmentErrors.OperationError;
                response.ErrorDesc = ex.Message;
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
        public BaseResponse CreateAccount(ChangeAccountRequest request)
        {
            var response = new BaseResponse();


            if (request.Account == null)
            {
                response.ErrorId = (int)RApmentErrors.FailedProceedRequest;
                return response;
            }

            try
            {
                response.ErrorId = (int)RApmentErrors.Ok;
                AccountDto dto = request.Account;
                Account account = new Account
                {
                    AccountId = dto.AccountId,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Email = dto.Email,
                    IsEmailConfirmed = false,
                   // C_Country = dto.Country,
                   //C_Roles = dto.Roles,
                    City = dto.City,
                    Address = dto.Address,
                    Mobile = dto.Mobile,
                    Gender = dto.Gender,
                    PostalCode = dto.PostalCode,
                    //Language = dto.Language
                    PictureUrl = dto.PictureUrl,
                    PasswordHash="",
                    FK__Roles = 1,
                    FK__Country = 1
                    

                };
               

                bool result =
                    RentApartmentManager.Instance.CreateAccount(account);
                
            }
            catch (Exception ex)
            {
                response.ErrorId = (int)RApmentErrors.OperationError;
                response.ErrorDesc = ex.Message;
                //Logger.Instance.Error("AuthenticateChatHost - ", ex);
            }

            return response;
        }

        public BaseResponse UpdateAccount(ChangeAccountRequest request)
        {
            var response = new BaseResponse();


            if (request.Account == null)
            {
                response.ErrorId = (int)RApmentErrors.FailedProceedRequest;
                return response;
            }

            try
            {
                response.ErrorId = (int)RApmentErrors.Ok;
                AccountDto dto = request.Account;
                Account account = new Account
                {
                    AccountId = dto.AccountId,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Email = dto.Email,
                    IsEmailConfirmed = false,
                    // C_Country = dto.Country,
                    // C_Roles = dto.Roles,
                    City = dto.City,
                    Address = dto.Address,
                    Mobile = dto.Mobile,
                    Gender = dto.Gender,
                    PostalCode = dto.PostalCode,
                    //Language = dto.Language
                    PictureUrl = dto.PictureUrl

                };


                bool result =
                    RentApartmentManager.Instance.UpdateAccount(account);
            }
            catch (Exception ex)
            {
                response.ErrorId = (int)RApmentErrors.OperationError;
                response.ErrorDesc = ex.Message;
                //Logger.Instance.Error("AuthenticateChatHost - ", ex);
            }

            return response;
        }
        public BaseResponse RemoveAccount(int accountId)
        {
            var response = new BaseResponse();

            try
            {
                response.ErrorId = (int)RApmentErrors.Ok;
                bool result =
                    RentApartmentManager.Instance.RemoveAccount(accountId);

            }
            catch (Exception ex)
            {
                response.ErrorId = (int)RApmentErrors.OperationError;
                response.ErrorDesc = ex.Message;
            }

            return response;
        }

        public AmenitiesResponse GetAmenities()
        {
            var response = new AmenitiesResponse();

            try
            {
                response.ErrorId = (int)RApmentErrors.Ok;

                IEnumerable<C_Amenities> amenities = RentApartmentManager.Instance.GetAmenities();

                //foreach (var item in amenities)
                //{
                //	var amenity = new AmenityDto()
                //	{
                //		id = item.id,
                //		Name = item.Name,
                //		Description = item.Description,
                //		IsActive = item.IsActive
                //	};
                //	response.Amenities.Add(amenity);
                //}
                List<AmenityDto> amenitiesDto = Mapper.Map<List<C_Amenities>, List<AmenityDto>>(amenities.ToList());
                response.Amenities = amenitiesDto;
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

        public GetDictionaryDataResponse GetGender()
        {
            var response = new GetDictionaryDataResponse();
            try
            {
                response.Data = GetDictionary<GenderType>();

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
