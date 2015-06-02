using RentAppartment.Client.RApmentAdminService;
using RentAppartment.Client.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAppartment.Client.DataAccess
{
	public class AppartmentsRepository : IDisposable
    {
        private readonly IRApmentAdministration _service;
        public AppartmentsRepository(IRApmentAdministration service)
        {
            _service = service;
        }

		public AccountDto Authenticate(string login, string pwd)
		{
			AccountDto profile = null;
			try
			{

				var request = new AuthenticationRequest()
				{
					Login = login,
					Password = CryptoHelper.CreateMD5Hash(pwd)
				};
				var response = _service.Authenticate(request);
				if (response != null)
				{
					if (response.ErrorId == 0)
					{
						profile = response.AuthenticationResult == true ? response.AccountProfile : null;
					}


				}
			}
			catch (Exception)
			{

			}

			return profile;
		}

        public List<PropertyDto> GetPropertyListings(string city, int? ownerId, 
                                                int? propertyId, int? homeType, int? roomNumbers )
        {

            List<PropertyDto> properties = new List<PropertyDto>();
            try 
	        {
		        GetPropertyListingRequest request = new GetPropertyListingRequest()
                {
                    City = city,
                    OwnerId = ownerId,
                    PropertyId = propertyId,
                    HomeType = homeType,
                    RoomNumbers = roomNumbers
                };

                GetPropertyListingResponse response = _service.GetPropertyListing(request);
                if (response != null )
                {
                    if (response.ErrorId == 0)
                    {
                        properties = response.PropertListing.ToList();
                    }
                    else
                    {
                        //Add to Log message
                    }
                    
                }
               
	        }
	        catch (Exception)
	        {
		
		        throw;
	        }

            return properties;
        }

		internal List<PropertyDto> GetPropertyByAccount(int accountId)
		{
			List<PropertyDto> properties = new List<PropertyDto>();
			try
			{

				GetPropertyListingResponse response = _service.GetPropertyByAccount(accountId);
				if (response != null)
				{
					if (response.ErrorId == 0)
					{
						properties = response.PropertListing.ToList();
					}
					else
					{
						//Add to Log message
					}

				}

			}
			catch (Exception)
			{

				throw;
			}

			return properties;
		}


		internal List<ReservationDto> GetUserBookedProperties(int accountId)
		{
			var reservations = new List<ReservationDto>();
			try
			{

				//GetPropertyListingResponse response = _service.GetBookedPropertyByAccount(accountId);
				var request = new GetReservationsRequest()
				{
					AccountId = accountId
				};

				GetReservationsResponse response = _service.GetReservations(request);
				if (response != null)
				{
					if (response.ErrorId == 0)
					{
						reservations = response.Reservation.ToList();
					}
					else
					{
						//Add to Log message
					}

				}

			}
			catch (Exception)
			{

				throw;
			}

			return reservations;
			;
		}
        public bool CreateProperty(PropertyDto apartment)
        {
            bool result = true;
            try
            {
                var request = new ChangedPropertyRequest();
                request.Property = apartment;
                BaseResponse response = _service.CreateProperty(request);
                if (response != null)
                {
                    if (response.ErrorId != 0)
                    {
                        result = false;//Add to Log message
                    }

                }

            }
            catch (Exception)
            {
                result = false;
                //throw;
            }

            return result;
        }
        public bool UpdateProperty(PropertyDto apartment)
        {
            bool result = true;
            try
            {
                var request = new ChangedPropertyRequest();
                request.Property = apartment;
                BaseResponse response = _service.UpdateProperty(request);
                if (response != null)
                {
                    if (response.ErrorId != 0)
                    {
                        result = false;//Add to Log message
                    }

                }

            }
            catch (Exception)
            {
                result = false;
                //throw;
            }

            return result;
        }

        public bool RemoveProperty(int propertyId)
        {
            bool result = true;
            try
            {

                BaseResponse response = _service.RemoveProperty(propertyId);
                if (response != null)
                {
                    if (response.ErrorId != 0)
                    {
                        result = false;//Add to Log message
                    }

                }

            }
            catch (Exception)
            {
                result = false;
                //throw;
            }

            return result;
        }

        public bool CreateAccount(AccountDto account)
        {
            bool result = true;
            try
            {
                var request = new ChangeAccountRequest();
                request.Account = account;
                BaseResponse response = _service.CreateAccount(request);
                if (response != null)
                {
                    if (response.ErrorId != 0)
                    {
                        result = false;//Add to Log message
                    }

                }

            }
            catch (Exception)
            {
                result = false;
                //throw;
            }

            return result;
        }
        public bool RemoveAccount(int accountId)
        {
            bool result = true;
            try
            {
                
                BaseResponse response = _service.RemoveAccount(accountId);
                if (response != null)
                {
                    if (response.ErrorId != 0)
                    {
                        result = false;//Add to Log message
                    }

                }

            }
            catch (Exception)
            {
                result = false;
                //throw;
            }

            return result;
        }
        public bool UpdateAccount(AccountDto account)
        {
            bool result = true;
            try
            {
                var request = new ChangeAccountRequest();
                request.Account = account;
                BaseResponse response = _service.UpdateAccount(request);
                if (response != null)
                {
                    if (response.ErrorId != 0)
                    {
                        result = false;//Add to Log message
                    }

                }

            }
            catch (Exception)
            {
                result = false;
                //throw;
            }

            return result;
        }

        public List<AccountDto> GetAccounts(int? accountId, string name, string city)
        {
            List<AccountDto> accounts = new List<AccountDto>();
            try
            {
                GetAccountsRequest request = new GetAccountsRequest()
                {
                    AccountId = accountId,
                    Name = name,
                    City = city
                };

                GetAccountsResponse response = _service.GetAccounts(request);
                if (response != null)
                {
                    if (response.ErrorId == 0)
                    {
                        accounts = response.Accounts.ToList();
                    }
                    else
                    {
                        //Add to Log message
                    }

                }

            }
            catch (Exception)
            {

                throw;
            }

            return accounts;
        }

        public List<AmenityDto> GetAmenitites()
        {
            List<AmenityDto> amenities = new List<AmenityDto>();
            try
            {
               

                AmenitiesResponse response = _service.GetAmenities();
                if (response != null)
                {
                    if (response.ErrorId == 0)
                    {
                        amenities = response.Amenities.ToList();
                    }
                    else
                    {
                        //Add to Log message
                    }

                }

            }
            catch (Exception)
            {

                throw;
            }
            return amenities;
        }
        public List<DateTime> GetApartmentReservations(int propertyId)
        {
            var reservations = new List<DateTime>();
            try
            {


                GetApartmentReservationsResponse response = _service.GetApartmentReservation(propertyId);
                if (response != null)
                {
                    if (response.ErrorId == 0)
                    {
                        reservations = response.BlackOutDates.ToList();
                    }
                    else
                    {
                        //Add to Log message
                    }

                }

            }
            catch (Exception)
            {

                throw;
            }
            return reservations;
        }

        public bool MakeReservation(int accountId, int propertyId, DateTime startDate, DateTime endDate, string note)
        {
            bool result = true; 
            try
            {
                BaseResponse response = _service.MakeApartmentReservation(accountId, propertyId, startDate, endDate, note);
                if (response != null)
                {
                    if (response.ErrorId != 0)
                    {
                        result = false;//Add to Log message
                    }

                }

            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

		public List<ReservationDto> GetReservations(string city, DateTime? start, DateTime? end)
		{
			var reservations = new List<ReservationDto>();
			try
			{
				var request = new GetReservationsRequest()
				{
					City = city,
					ReservationStart = start,
					ReservationEnd = end
				};

				GetReservationsResponse response = _service.GetReservations(request);
				if (response != null)
				{
					if (response.ErrorId == 0)
					{
						reservations = response.Reservation.ToList();
					}
					else
					{
						//Add to Log message
					}

				}

			}
			catch (Exception)
			{

				throw;
			}
			return reservations;
		}

		internal bool AddReview(int propertyId, int accountId, int score, string reviewNotes)
		{
			try
			{
				BaseResponse response = _service.AddPropertyReview(propertyId, accountId, score, reviewNotes);
				if (response != null)
				{
					if (response.ErrorId != 0)
					{
						return false;
					}
					else
					{
						//Add to Log message
					}

				}

			}
			catch (Exception)
			{

				throw;
			}
			return true;
		}
	
		///
        ///
        #region Dictionaries
        public Dictionary<int, string> GetHomeTypes()
        {
            var dict = new Dictionary<int, string>();
            try
            {
                var cachedItem = CacheProvider.Instance.GetItem("HomeTypes");
                if (cachedItem != null)
                {
                    dict = (Dictionary<int, string>)cachedItem;
                }
                else
                {
                    GetDictionaryDataResponse response = _service.GetHomeType();
                    if (response != null)
                    {
                        if (response.ErrorId == 0)
                        {
							dict = response.Data;
                            CacheProvider.Instance.AddItem("HomeTypes", dict);
                        }
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }

            return dict;
        }

        public Dictionary<int, string> GetRoomTypes()
        {
            var dict = new Dictionary<int, string>();
            try
            {
                var cachedItem = CacheProvider.Instance.GetItem("RoomTypes");
                if (cachedItem != null)
                {
                    dict = (Dictionary<int, string>)cachedItem;
                }
                else
                {
                    GetDictionaryDataResponse response = _service.GetRoomType();
                    if (response != null)
                    {
                        if (response.ErrorId == 0)
                        {
                            dict = response.Data;
                            CacheProvider.Instance.AddItem("RoomTypes", dict);
                        }
                    }
                }
                
            }
            catch (Exception)
            {

                throw;
            }

            return dict;
        }

        public Dictionary<int, string> GetUserRoles()
        {
            var dict = new Dictionary<int, string>();
            try
            {
                var cachedItem = CacheProvider.Instance.GetItem("UserRoles");
                if (cachedItem != null)
                {
                    dict = (Dictionary<int, string>)cachedItem;
                }
                else
                {
                    GetDictionaryDataResponse response = _service.GetUserRole();
                    if (response != null)
                    {
                        if (response.ErrorId == 0)
                        {
                            dict = response.Data;
                            CacheProvider.Instance.AddItem("UserRoles", dict);
                        }
                    }
                }
                
            }
            catch (Exception)
            {

                throw;
            }

            return dict;
        }

        public Dictionary<int, string> GetGenderTypes()
        {
            var dict = new Dictionary<int, string>();
            try
            {
                var cachedItem = CacheProvider.Instance.GetItem("GenderTypes");
                if (cachedItem != null)
                {
                    dict = (Dictionary<int, string>)cachedItem;
                }
                else
                {
                    GetDictionaryDataResponse response = _service.GetGender();
                    if (response != null)
                    {
                        if (response.ErrorId == 0)
                        {
                            dict = response.Data;
                            CacheProvider.Instance.AddItem("GenderTypes", dict);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return dict;
        }
		public void Dispose()
		{

        }
        #endregion




	}
}
