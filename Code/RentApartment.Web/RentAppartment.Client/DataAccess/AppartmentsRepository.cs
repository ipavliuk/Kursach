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

        ///Dictionaries
        ///
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

		public void Dispose()
		{
			
		}
	}
}
