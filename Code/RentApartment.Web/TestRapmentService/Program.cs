using RentApartment.Core.Infrastructure;
using RentApartment.Core.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRapmentService
{
	class Program
	{
		static void Main(string[] args)
		{
            LoadPropertiesByFiter();
		}

        static void LoadPropertiesByFiter()
        {
            List<PropertyListing> propertyListings =
                    RentApartmentManager.Instance.LoadPropertyListingByFilter("Houston", null,
                                                    null, null, null).ToList();
        }

	}
}
