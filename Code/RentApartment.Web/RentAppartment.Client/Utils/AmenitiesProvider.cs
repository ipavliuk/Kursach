using RentAppartment.Client.RApmentAdminService;
using RentAppartment.Client.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAppartment.Client.Utils
{
    public class AmenitiesProvider //: ViewModelBase
    {
        public AmenitiesProvider()
        {

        }

        private readonly List<AmenityDto> _amenities;
        public AmenitiesProvider(List<AmenityDto> amenities)
        {

            _amenities = amenities;
        }

        public bool Toilet { get; set; }
        public bool TV { get; set; }

        public bool Cable { get; set; }

        public bool Heating { get; set; }
        public bool Condition { get; set; }
        public bool Wifi { get; set; }
        public bool Citchen { get; set; }
        public bool Washmachine { get; set; }
        public bool Parking { get; set; }
        public bool Fireplace { get; set; }
        public bool Fridge { get; set; }
        public bool Jacuzzi { get; set; }
        public bool Elevator { get; set; }
        public bool Animals { get; set; }
        public bool Smocking { get; set; }


        public List<AmenityDto> GetSelectedAmenitites()
        {

            var list = new List<AmenityDto>();
            try 
	        {
                if (Toilet) list.Add(_amenities.Where(a => a.id == 1).First());

                if (TV) list.Add(_amenities.Where(a => a.id == 2).First());

                if (Cable) list.Add(_amenities.Where(a => a.id == 3).First());
            
                if (Heating) list.Add(_amenities.Where(a => a.id == 4).First());
            
                if (Condition) list.Add(_amenities.Where(a => a.id == 5).First());
            
                if (Wifi) list.Add(_amenities.Where(a => a.id == 6).First());
            
                if (Citchen) list.Add(_amenities.Where(a => a.id == 7).First());
            
                if (Washmachine) list.Add(_amenities.Where(a => a.id == 8).First());
            
                if (Parking) list.Add(_amenities.Where(a => a.id == 9).First());
            
                if (Fireplace) list.Add(_amenities.Where(a => a.id == 10).First());
            
                if (Fridge) list.Add(_amenities.Where(a => a.id == 11).First());
            
                if (Jacuzzi) list.Add(_amenities.Where(a => a.id == 12).First());
            
                if (Elevator) list.Add(_amenities.Where(a => a.id == 13).First());
            
                if(Animals) list.Add(_amenities.Where(a => a.id == 14).First());

                if (Smocking) list.Add(_amenities.Where(a => a.id == 15).First());
            
	        }
	        catch (Exception ex)
	        {
		
		        throw;
	        }
            

            return list;
        }

        public void SetAmenitiesModel(List<AmenityDto> amenities)
        {
            try
            {
                Toilet = amenities.Where(a => a.id == 1).FirstOrDefault() != null;

                TV = amenities.Where(a => a.id == 2).FirstOrDefault() != null;

                Cable = amenities.Where(a => a.id == 3).FirstOrDefault() != null;

                Heating = amenities.Where(a => a.id == 4).FirstOrDefault() != null;

                Condition = amenities.Where(a => a.id == 5).FirstOrDefault() != null;

                Wifi = amenities.Where(a => a.id == 6).FirstOrDefault() != null;

                Citchen = amenities.Where(a => a.id == 7).FirstOrDefault() != null;

                Washmachine = amenities.Where(a => a.id == 8).FirstOrDefault() != null;

                Parking = amenities.Where(a => a.id == 9).FirstOrDefault() != null;

                Fireplace = amenities.Where(a => a.id == 10).FirstOrDefault() != null;

                Fridge = amenities.Where(a => a.id == 11).FirstOrDefault() != null;

                Jacuzzi = amenities.Where(a => a.id == 12).FirstOrDefault() != null;

                Elevator = amenities.Where(a => a.id == 13).FirstOrDefault() != null;

                Animals = amenities.Where(a => a.id == 14).FirstOrDefault() != null;

                Smocking = amenities.Where(a => a.id == 15).FirstOrDefault() != null;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
