using RentAppartment.Client.RApmentAdminService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAppartment.Client.DataAccess
{
    public class AppartmentsRepository
    {
        private readonly IRApmentAdministration _service;
        public AppartmentsRepository(IRApmentAdministration service)
        {
            _service = service;
        }

        public IList<PropertyDto> GetProperties(string city, int? ownerId, 
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
                    if (response.ErrorId != 0)
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



        //List<> GetPropertyListing()
        //{
        //}
    }
}
