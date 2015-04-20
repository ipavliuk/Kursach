using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentApartment.Core.Model.EF;

namespace RentApartment.Core.Infrastructure
{
    interface IPropertyListingService
	{
		Account Authenticate(string login, string password);

		Account GetAccountById(int id);
        IEnumerable<Account> GetAccountsByFilter(int? accountId, string name, string city);

		IEnumerable<PropertyListing> GetPropertyByAccount(int accountId);

		IEnumerable<PropertyListing> GetPropertyByCityCountry(string city, int country);

		//IEnumerable<PropertyListing> GetPropertyListings();

        IEnumerable<Reservations> GetReservationsByDate(DateTime startDate, DateTime endDate, int? status, string city);

		IEnumerable<Reservations> GetReservationsByAccount(int accountId);
        IEnumerable<PropertyListing> GetPropertyListingByFilter(string city, int? homeType, int? roomNumbers);
		IEnumerable<C_Country> GetCountries();
		IEnumerable<C_Roles> GetRoles();
		IEnumerable<C_Currency> GetCurrencies();
		IEnumerable<C_Amenities> GetAmenities();

        IEnumerable<DateTime> GetApartmentReservationDates(int apartmentId);

        bool MakeApartmentReservation(int accountId, int propertyId, DateTime startDate, DateTime endDate, string note);
        bool CreateProperty(PropertyListing property);
        bool UpdateProperty(PropertyListing property);
    }
}
